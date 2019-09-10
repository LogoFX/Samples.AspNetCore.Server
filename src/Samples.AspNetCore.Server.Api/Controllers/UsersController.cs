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
        /// Gets users.
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
                return new BadRequestObjectResult($"Unable to retrieve algorithms: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes user by user name.
        /// </summary>
        /// <param name="username">User's name.</param>
        /// <returns>The list of users.</returns>
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(string username)
        {
            try
            {
                var users = await _usersProvider.GetUsersAsync();
                var user = users.SingleOrDefault(x => string.Compare(x.Username, username, StringComparison.OrdinalIgnoreCase) == 0);
                if (user == null)
                {
                    return NotFound($"User '{username}' not found.");
                }

                await _usersProvider.RemoveUserAsync(user);

                return Ok((await _usersProvider.GetUsersAsync()).Select(u => u.ToModel()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to retrieve algorithms: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates user's data'.
        /// </summary>
        /// <param name="username">User's name.</param>
        /// <param name="newFullname">New user's full name.'</param>
        /// <returns>The list of users.</returns>
        [HttpGet("Update")]
        public async Task<IActionResult> Update(string username, string newFullname)
        {
            try
            {
                var users = await _usersProvider.GetUsersAsync();
                var user = users.SingleOrDefault(x => string.Compare(x.Username, username, StringComparison.OrdinalIgnoreCase) == 0);
                if (user == null)
                {
                    return NotFound($"User '{username}' not found.");
                }

                await _usersProvider.UpdateUserAsync(user, newFullname);

                return Ok((await _usersProvider.GetUsersAsync()).Select(u => u.ToModel()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to retrieve algorithms: {ex.Message}");
            }
        }
    }
}