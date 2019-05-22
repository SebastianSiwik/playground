using BicycleService.Api.BindingModels;
using BicycleService.Api.Validation;
using BicycleService.Api.ViewModels;
using BicycleService.Data.Sql;
using BicycleService.Data.Sql.DAO;
using BicycleService.Utils.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.Controllers
{   
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly BicycleServiceDbContext _context;

        public UserController(BicycleServiceDbContext context)
        {
            _context = context;
        }

        [Route("{userId:min(1)}", Name = "GetUserById")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            
            if(user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    Address = user.Address,
                    RegistrationDate = user.RegistrationDate,
                    BirthDate = user.BirthDate,
                    IsBannedUser = user.IsBannedUser,
                    UserStatus = user.UserStatus
                });
            }
            return NotFound();
        }

        [Route("name/{userName}", Name = "GetUserByUserName")]
        [HttpGet]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    Address = user.Address,
                    RegistrationDate = user.RegistrationDate,
                    BirthDate = user.BirthDate,
                    IsBannedUser = user.IsBannedUser,
                    UserStatus = user.UserStatus
                });
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new User
            {
                UserName = createUser.UserName,
                UserEmail = createUser.UserEmail,
                BirthDate = createUser.BirthDate,
                RegistrationDate = DateTime.UtcNow,
                IsBannedUser = false,
                UserStatus = UserStatus.User.ToString()
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created(user.UserId.ToString(), new UserViewModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                Address = user.Address,
                RegistrationDate = user.RegistrationDate,
                BirthDate = user.BirthDate,
                IsBannedUser = user.IsBannedUser,
                UserStatus = user.UserStatus
            });
        }

        [Route("edit/{userId:min(1)}", Name = "EditUser")]
        [ValidateModel]
        [HttpPatch]
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            user.UserName = editUser.UserName;
            user.UserEmail = editUser.UserEmail;
            user.BirthDate = editUser.BirthDate;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Route("delete/{userId:min(1)}", Name = "DeleteUser")]
        [ValidateModel]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
