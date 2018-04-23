using System;
using Microsoft.AspNetCore.Authentication;

namespace PMProjet.Authentication
{
    public static class AdminAuthExtensions
    {
        public static AuthenticationBuilder AddAdminAuth(this AuthenticationBuilder builder, Action<AdminAuthOptions> configureOptions)
        {
            return builder.AddScheme<AdminAuthOptions, AdminAuthHandler>("Admin", "AdminAuth", configureOptions);
        }
    }
}