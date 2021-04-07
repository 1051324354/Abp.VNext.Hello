﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;

namespace Abp.VNext.Hello
{
    /// <summary>
    /// https://github.com/abpframework/abp/issues/2930
    /// </summary>
    public class MyUserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory
    {
        public MyUserClaimsPrincipalFactory(UserManager<Volo.Abp.Identity.IdentityUser> userManager, RoleManager<Volo.Abp.Identity.IdentityRole> roleManager, IOptions<IdentityOptions> options, ICurrentPrincipalAccessor currentPrincipalAccessor, IAbpClaimsPrincipalFactory abpClaimsPrincipalFactory)
            : base(userManager, roleManager, options, currentPrincipalAccessor, abpClaimsPrincipalFactory)
        {

        }
        public override async Task<ClaimsPrincipal> CreateAsync(Volo.Abp.Identity.IdentityUser user)
        {
            ClaimsPrincipal principal = await base.CreateAsync(user);
            principal.Identities
                  .First()
                  .AddClaim(new Claim("merchant", "Angkor"));
            return principal;
        }

    }
}
