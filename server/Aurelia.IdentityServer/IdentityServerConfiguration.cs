using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Aurelia.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource> {
                new IdentityResources.OpenId() ,
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[] {
                new ApiResource( "aurelia_web_api" , "Aurelia WebApi") {
                    ApiSecrets = { new Secret( "apisecret".Sha256() ) }
                }
            };

        public static List<TestUser> Users => new List<TestUser>() {
            new TestUser() {
                SubjectId = "1D9F016D-58A9-4256-85A1-188ACE29DB44",
                Username = "shahab" ,
                Password = "password"                                                    }
        };

        // those who want to get access to protected resources, such as api or identity resources
        public static IEnumerable<Client> Clients => new List<Client>(){
            new Client() {
                ClientId = "aurelia_web_api_client_spa",
                ClientName = "Aurelia SPA Application",

                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true ,

                RedirectUris = { "https://localhost:44347/signin-oidc" } ,
                PostLogoutRedirectUris = { "https://localhost:44347/signout-oidc" },
                AllowedCorsOrigins = { "https://localhost:44347" } ,

                AllowedScopes = new List<string>() {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile ,
                    "aurelia_web_api"
                }
            }
        };
    }
}