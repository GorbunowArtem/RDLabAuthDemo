# Small demo to show how Jwt, OAuth works

## RDLabAuthDemo.BasicJwt
- init local secrets store
- navigate to `src\RDLabAuthDemo.BasicJwt` directory and execute:
```c#
dotnet user-secrets init
```
- set values for each value
```c#
dotnet user-secrets set "JwtToken:Key" "YOUR_KEY"
```
- do the same for `Issuer` and `Audience`      
- to see all local secrets execute
```c#
dotnet user-secrets list
```
- more details can be found [here](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)

## RDLabAuthDemo.IdentityServer
- install identity server templates
```c#
dotnet new -i IdentityServer4.Templates
```
- used this quickstart [guide](https://identityserver4.readthedocs.io/en/latest/quickstarts/1_client_credentials.html)