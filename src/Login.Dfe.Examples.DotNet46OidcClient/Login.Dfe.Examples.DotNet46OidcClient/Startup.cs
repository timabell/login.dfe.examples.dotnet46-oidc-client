﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(Login.Dfe.Examples.DotNet46OidcClient.Startup))]

namespace Login.Dfe.Examples.DotNet46OidcClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "bats", // becoming a teacher service
                Authority = "https://signin-test-oidc-as.azurewebsites.net/", // test dfe sign-in system
                RedirectUri = "https://localhost:44364/auth/cb",
                ResponseType = "id_token",
                Scope = "openid email",

                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
            });
        }
    }
}
