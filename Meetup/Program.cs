using MediatR;
using Meetup.Data.Data;
using Meetup.Data.Interfaces;
using Meetup.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Meetup.Application.Extentions;
using Microsoft.OpenApi.Models;
using IdentityServer4.AccessTokenValidation;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Password = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri("https://localhost:10001/connect/token"),
                Scopes = new Dictionary<string, string>{}
            }
        }
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
})
    .AddIdentityServerAuthentication(options =>
    {
        options.ApiName = "EventAPI";
        options.Authority = "https://localhost:10001";
        options.RequireHttpsMetadata = false;
    });
builder.Services.AddAuthorization();

builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.ConfigureMediatR();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId("client_id_eventApi");
        options.OAuthScopeSeparator(" ");
        options.OAuthClientSecret("client_secret_eventApi");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
