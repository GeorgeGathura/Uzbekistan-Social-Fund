using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Uzbekistan_Social_Fund.Data
{
    public class SocialFundDbContext : IdentityDbContext
    {
        public SocialFundDbContext(DbContextOptions<SocialFundDbContext> options):base(options)
        {

        }

    }
}
