using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Meetup.Authorization.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<Client> GetClients() =>

            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id_eventApi",
                    ClientSecrets = { new Secret("client_secret_eventApi".ToSha256()) },
                    AllowedGrantTypes =  GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:5001" },
                    AllowedScopes =
                    {
                        "EventAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
        
            new List<ApiResource>
            {
                new ApiResource("EventAPI")
                {
                    Scopes = new List<string>
                    {
                        "EventAPI"
                    },
                },
            };
        
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        /// <summary>
        /// IdentityServer4 version 4.x.x changes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("EventAPI", "Event API");
        }
    }
}
