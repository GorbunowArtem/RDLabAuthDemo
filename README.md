# Small demo to show how Jwt, OAuth works

## RDLabAuthDemo.BasicJwt

1. Set required variables.

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

- more details can be
  found [here](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)

2. Run `RDLabAuthDemo.BasicJwt` project:

- try to get [weather forecast](https://localhost:5001/weather), result must be 401.
- in order to call this endpoint we need to get access token. Navigate
  to [token endpoint](https://localhost:5001/token?userName=artem&password=securePassword) with user name and password.
- use this token to call [weather forecast](https://localhost:5001/weather). You can add it to request header:

```c#
Bearer [PUT_YOUR_TOKEN_HERE]
```

- or use Postman, select `Authorization` tab and pick `Bearer Token` in list. Paste your token to the field.

## RDLabAuthDemo.IdentityServer

There are 2 examples: with [Implicit Flow](https://auth0.com/docs/flows/implicit-flow-with-form-post)
and [Client Credentials](https://auth0.com/docs/flows/client-credentials-flow). How to choose flow read [here](https://auth0.com/docs/authorization/which-oauth-2-0-flow-should-i-use)

1. Client Credentials

- run `RDLabAuthDemo.IdentityServer` and `RDLabAuthDemo.IdentityServer.Api` projects.
- open Postman, create new request to [weather forecast](https://localhost:5003/weather) and execute, result must be 401.
- select `Authorization` tab, select type `OAuth 2.0`
- on right panel choose
  ```config
  Grant Type: Client Credentials
  Access Token URL: https://localhost:5004/connect/token
  Client ID: rdlab.client
  Client Secret: 511536EF-F270-4058-80CA-1C89C192F69A
  Scope: rdLabApi
  ```
- these values are taken from `Config.cs` file of `RDLabAuthDemo.IdentityServer` project
- select `Get New Access Token` save it and try to execute request one more time
  
2. Implicit Flow
- make sure you are running `RDLabAuthDemo.IdentityServer` and `RDLabAuthDemo.IdentityServer.MVC` projects
- try to navigate to [Home page](https://localhost:5004)
- Identity Server login page must be shown 
- enter `bob` as username and `bob` as password
- give permissions to use your data

3. To try Identity Server on your own, install identity server templates

```c#
dotnet new -i IdentityServer4.Templates
```

- use this quickstart [guide](https://identityserver4.readthedocs.io/en/latest/quickstarts/1_client_credentials.html)