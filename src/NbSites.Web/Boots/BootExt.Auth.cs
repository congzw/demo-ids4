using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Web.Boots
{
    public static partial class BootExt
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void AddMyAuth(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
                
            }).AddCookie("Cookies", options =>
               {
                   options.AccessDeniedPath = "/Authorization/AccessDenied";
               })
              .AddOpenIdConnect("oidc", options =>
              {
                  options.SignInScheme = "Cookies";
                  options.Authority = "http://localhost:8309";
                  options.ClientId = "imagegalleryclient";
                  options.ResponseType = "code id_token";
                  //options.CallbackPath = new PathString("...")
                  options.Scope.Add("openid");
                  options.Scope.Add("profile");
                  options.SaveTokens = true;
                  options.ClientSecret = "secret";

                  //InvalidOperationException: The MetadataAddress or Authority must use HTTPS unless disabled for development by setting RequireHttpsMetadata=false.
                  options.RequireHttpsMetadata = false;
              });
        }


        public static void UseMyAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
        }

        //public static void AddAuth(IServiceCollection services)
            //{
            //    services.AddAuthorization(authorizationOptions =>
            //    {
            //        authorizationOptions.AddPolicy(
            //            "CanOrderFrame",
            //            policyBuilder =>
            //            {
            //                policyBuilder.RequireAuthenticatedUser();
            //                policyBuilder.RequireClaim("country", "be");
            //                policyBuilder.RequireClaim("subscriptionlevel", "PayingUser");
            //            });
            //    });


            //    services.AddAuthentication(options =>
            //    {
            //        options.DefaultScheme = "Cookies";
            //        options.DefaultChallengeScheme = "oidc";
            //    }).AddCookie("Cookies", options =>
            //    {
            //        options.AccessDeniedPath = "/Authorization/AccessDenied";
            //    })
            //      .AddOpenIdConnect("oidc", options =>
            //      {
            //          options.SignInScheme = "Cookies";
            //          options.Authority = "http://localhost:8309";
            //          options.ClientId = "imagegalleryclient";
            //          options.ResponseType = "code id_token";
            //          //options.CallbackPath = new PathString("...")
            //          //options.SignedOutCallbackPath = new PathString("...")
            //          options.Scope.Add("openid");
            //          options.Scope.Add("profile");
            //          options.Scope.Add("address");
            //          options.Scope.Add("roles");
            //          options.Scope.Add("subscriptionlevel");
            //          options.Scope.Add("country");
            //          options.Scope.Add("imagegalleryapi");
            //          options.Scope.Add("offline_access");
            //          options.SaveTokens = true;
            //          options.ClientSecret = "secret";
            //          options.GetClaimsFromUserInfoEndpoint = true;
            //          options.ClaimActions.Remove("amr");
            //          options.ClaimActions.DeleteClaim("sid");
            //          options.ClaimActions.DeleteClaim("idp");
            //          //options.ClaimActions.DeleteClaim("address");
            //          options.ClaimActions.MapUniqueJsonKey("role", "role");
            //          options.ClaimActions.MapUniqueJsonKey("subscriptionlevel", "subscriptionlevel");
            //          options.ClaimActions.MapUniqueJsonKey("country", "country");


            //          options.TokenValidationParameters = new TokenValidationParameters
            //          {
            //              NameClaimType = JwtClaimTypes.GivenName,
            //              RoleClaimType = JwtClaimTypes.Role,
            //          };

            //      });


            //}
        }
}
