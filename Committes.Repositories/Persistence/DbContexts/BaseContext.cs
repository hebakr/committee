using Committes.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Repositories.Persistence.DbContexts
{
    public class BaseContext<TContext> : IdentityDbContext<ApplicationUser> where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext() : base("name=CommitteesConnectionString")
        {

        }
    }
}
