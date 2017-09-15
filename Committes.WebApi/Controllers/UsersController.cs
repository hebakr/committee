using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.Repositories.Persistence.DbContexts;
using Committes.WebApi.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Committes.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private ApplicationUserManager _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return _roleManager ?? new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Request.GetOwinContext().Get<AppDbContext>()));
            }
            private set
            {
                _roleManager = value;
            }
        }

        public UsersController()
        {
            
        }

        public IHttpActionResult Get()
        {
            var users = UserManager.Users;

            return Ok(new { users = users.Select(u => new { u.Id, u.Name, u.Email, u.UserName, IsAdmin = u.Roles.Any(x => x.RoleId == "admin") }) });
        }

        public async Task<IHttpActionResult> Post([FromBody]UserVM user)
        {
            if (!ModelState.IsValid) return BadRequest();

            var account = new ApplicationUser
            {
                Name = user.Name,
                Email = user.Email,
                UserName = user.Username
            };

            var result = await UserManager.CreateAsync(account, user.Password);

            if (user.IsAdmin) // add admin role 
                AddUserToAdminRole(account.Id);

            if (result.Succeeded)
                return  Ok();

            return BadRequest(string.Join("\n", result.Errors));
        }

        private void AddUserToAdminRole(string userId)
        {
            if (!RoleManager.RoleExists("admin"))
                RoleManager.Create(new IdentityRole { Id = "admin", Name = "admin" });

            var role = RoleManager.FindById("admin");
            UserManager.AddToRole(userId, "admin");
        }

        public async Task<IHttpActionResult> Put([FromBody]UserVM user)
        {
            if (!ModelState.IsValid) return BadRequest();

            var account = UserManager.FindById(user.Id);

            account.Name = user.Name;
            account.Email = user.Email;

            var result = await UserManager.UpdateAsync(account);

            if (user.IsAdmin)
                AddUserToAdminRole(account.Id);

            if (result.Succeeded)
                return Ok();

            return BadRequest(string.Join("\n", result.Errors));

        }

        public async Task<IHttpActionResult> ResetPassword([FromBody]ResetPasswordVM model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await UserManager.RemovePasswordAsync(model.Id);
            var result = await UserManager.AddPasswordAsync(model.Id, model.Password);

            if (result.Succeeded)
                return Ok();

            return BadRequest(string.Join("\n", result.Errors));

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var account = UserManager.FindById(id);

            if (account == null) return BadRequest();

            var result = await UserManager.DeleteAsync(account);

            if (result.Succeeded)
                return Ok();

            return BadRequest(string.Join("\n", result.Errors));
        } 

    }
}
