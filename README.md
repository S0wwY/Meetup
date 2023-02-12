# Meetup


* Необходимо в настройках поставить запуск двух проектов(Meetup.Authorization.IdentityServer и MeetupWebApi).
* При запуске открывается swagger и для дальнейшего взаимодействия требуется авторизация 
  + имя пользователя **user**
  + пароль **123qwe**
*********
 В базе данных изначально находится 2 места (Id = 1,Name = "Chelyuskintsev park", Id = 2,Name = "Gorky Park")
и 2 орагнизатора (Id = 1,Name = "Hi-Tech Park", Id = 2,Name = "OOO Systems").
*********
Event creation example (Post method)
```
{
  "eventName": "Test_Event",
  "description": "Any description",
  "time": "19:00",
  "date": "17.11.2023",
  "organizersIds": [
    1,2
  ],
  "placeId": 1
}
```
