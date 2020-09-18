using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Promp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promp.DAL
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<PromApiToken> PromApiTokens { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
