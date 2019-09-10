using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Samples.AspNetCore.Server.Data.Contracts.Providers;
using Samples.AspNetCore.Server.Api.Models;

namespace Samples.AspNetCore.Server.Api.Controllers
{
    /// <summary>
    /// Users controller.
    /// </summary>
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersProvider _usersProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Samples.AspNetCore.Server.Api.Controllers.UsersController"/> class.
        /// </summary>
        /// <param name="usersProvider">Users provider.</param>
        public UsersController(IUsersProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The list of users.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok((await _usersProvider.GetUsersAsync()).Select(u => u.ToModel()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to retrieve users: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets user by id.
        /// </summary>
        /// <returns>The user.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok((await _usersProvider.GetUserById(id)).ToModel());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to retrieve users: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets user by name.
        /// </summary>
        /// <returns>The user.</returns>
        [HttpGet("name/{username}")]
        public async Task<IActionResult> GetByName(string username)
        {
            try
            {
                return Ok((await _usersProvider.GetUserByName(username)).ToModel());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to retrieve users: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes user by user name.
        /// </summary>
        /// <param name="username">User's name.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string username)
        {
            try
            {
                var user = await _usersProvider.GetUserByName(username);
                if (user == null)
                {
                    return NotFound($"User '{username}' not found.");
                }

                await _usersProvider.RemoveUserAsync(user.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to delete the user: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates user's data'.
        /// </summary>
        /// <param name="username">User's name.</param>
        /// <param name="fullname">New user's full name.'</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(string username, string fullname)
        {
            try
            {
                var user = await _usersProvider.GetUserByName(username);
                if (user == null)
                {
                    return NotFound($"User '{username}' not found.");
                }

                await _usersProvider.UpdateUserAsync(user.Id, username, fullname);

                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to update the user: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds new user'.
        /// </summary>
        /// <param name="username">User's name.</param>
        /// <param name="fullname">User's full name.'</param>
        /// <returns>The list of users.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(string username, string fullname)
        {
            try
            {
                await _usersProvider.AddUserAsync(username, fullname);
                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to add a user: {ex.Message}");
            }
        }
    }
}