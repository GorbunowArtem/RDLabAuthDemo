// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace RDLabAuthDemo.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("rdLabApi"),
                new ApiScope("rdLabApiCode"),
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                // Client credentials flow client
                // https://auth0.com/docs/flows/client-credentials-flow
                new Client
                {
                    ClientId = "rdlab.client",
                    ClientName = "RD Lab demo Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "rdLabApi" }
                },

                // interactive client using code flow + pkce
                // https://auth0.com/docs/flows/authorization-code-flow-with-proof-key-for-code-exchange-pkce
                new Client
                {
                    ClientId = "rdlab.authcode.client",
                    ClientSecrets = {new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:6002/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:6002/signout-oidc",
                    PostLogoutRedirectUris = {"https://localhost:6002/signout-callback-oidc"},
                    AllowOfflineAccess = true,
                    RequirePkce = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rdLabApiCode"
                    }
                },
            };
    }
}