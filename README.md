# Meetup

* Необходимо в настройках поставить запуск двух проектов(Meetup.Authorization.IdentityServer и MeetupWebApi).
* При запуске открывается swagger и для дальнейшего взаимодействия требуется авторизация 
![https://www.google.com/search?q=swagger+authorization&sxsrf=AJOqlzUhRKuBzSn0vCpkfFwyQk10-git5g:1676211661298&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiqhI-Fl5D9AhXMiP0HHfU3BicQ_AUoAXoECAEQAw&biw=1920&bih=969&dpr=1#imgrc=RzR2TJSRE3W3nM&imgdii=cmxWdci7kWB8wM]
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
