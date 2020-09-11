# notes

## concepts

- IDP: Identity Provider
- IAM: Identity and Access Management
- OAuth2: a open protocol to allow secure authorization in a simple and standard method from web, mobile, desktop applications
- OIDC: OpenID Connect, a simple identity layer on top of the OAuth2 protocol (it extends OAuth2)


## problems of reinventing the wheel

- expiration
- token signing and validation
- token format
- authentication and authorization
- securely delivering tokens to different application types
- ...

## OIDC

### endpoints

- authorization endpoint
- token endpoint


## setup IdentityServer4 with UI

- Install-Package IdentityServer4 -Version 2.5.4
- download IdentityServer4.Templates 2.7.0 or
- download IdentityServer4.Quickstart.UI 2.5.0 and copy files to project
- config Startup
- todo: setup TLS?

``` ps1
iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/IdentityServer/IdentityServer4.Quickstart.UI/master/getmaster.ps1'))
# auto download fail as the "great-wall", so do it by hands, -_-!
# https://github.com/IdentityServer/IdentityServer4.Quickstart.UI/tree/2.5.0
``` 

``` shell
- git checkout tags/2.5.0 -b branch-2.5.0
```

```csharp
# config Startup
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        // rest omitted
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();
        app.UseIdentityServer();
        app.UseMvcWithDefaultRoute();
    }
}
```

## DEMO

- MyIDP => http://localhost:8309
- ImageGallery => http://localhost:2047
- NbSites.Web => http://localhost:12060
- public static bool AutomaticRedirectAfterSignOut = false;
- http://localhost:8309/.well-known/openid-configuration
