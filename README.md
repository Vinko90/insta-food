# InstaFood
ASP .NET Core v3.1 Food delivery system. The frontend is created using AdminLTE-3.0.2 template.

## Secret

The application use user secrets to manage the connection with the database, payment system with Stripe and Single Sign On services. The User secret look like the following: 

```JSON
{
  "ConnectionStrings": {
    "InstaFoodConnectionString": "Server=**hostname**;Database=InstaFoodDB;User Id=**username**;Password=**password**;MultipleActiveResultSets=true;"
  },
  "Stripe": {
    "PublicKey": "KEY",
    "SecretKey": "KEY"
  },
  "FacebookApp": {
    "AppId": "KEY",
    "AppSecret": "KEY"
  },
  "MicrosoftApp": {
    "ClientId": "KEY",
    "SecretId": "KEY"
  }
}
```
