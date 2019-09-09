﻿using System;
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

    }
}