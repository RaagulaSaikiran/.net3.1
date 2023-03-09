using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using signin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _SignInManager;

            public ApplicationUserController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> SignInManager)
        {
            _userManager = userManager;
            _SignInManager = SignInManager;
        }


        [HttpPost]
        [Route("Register")]

        public async Task<object> PostAppicationuser(ApplicationUserModel model)
        {
            var ApplicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                Fullname = model.Fullname
        };

            try
            {
                var result = await _userManager.CreateAsync(ApplicationUser, model.password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
 
    }
}
