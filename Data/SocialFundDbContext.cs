using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Uzbekistan_Social_Fund.Models;

namespace Uzbekistan_Social_Fund.Data
{
    public class SocialFundDbContext : IdentityDbContext
    {
        public SocialFundDbContext(DbContextOptions<SocialFundDbContext> options):base(options)
        {

        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<HouseMember> HouseMembers { get; set; }  
        
        public DbSet<MemberEducation> MemberEducations { get; set;}

        public DbSet<FundApplication> FundApplication { get; set; }

        public DbSet<County> Counties { get; set; }

        public DbSet<SubCounty> SubCounties { get; set; }

        public DbSet<Ward> Wards { get; set; }

    }
}
