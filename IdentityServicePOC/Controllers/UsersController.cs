using IdentityService.Core.Entities;
using IdentityService.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.API.Controllers
{
    /// <summary>
    /// Users Controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository iuserRepository;
        /// <summary>
        /// UsersController Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UsersController(IUserRepository userRepository)
        {
            iuserRepository = userRepository;
        }

        /// <summary>
        /// Get User details by Apl id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserDetailsEntity</returns>
        [HttpGet]
        [Route("UserId/{id}")]
        [ProducesResponseType(typeof(UserDetailEntity), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByApiId(string id)
        {
            UserDetailEntity userDetailEntity = await iuserRepository.GetUserByApiId(id);
            if(userDetailEntity == null)
            {
                return NotFound();
            }
            return Ok(userDetailEntity); 
        }

        /// <summary>
        /// Get User details by guid id in base64 format
        /// </summary>
        /// <param name="id"></param>
        /// 
        /// <returns>Base 64 Response</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByUserId(Guid id)
        {
            string base64Response = await iuserRepository.GetUserByUserId(id);
            if (string.IsNullOrEmpty(base64Response))
            {
                return NotFound();
            }
            return Ok(base64Response);
        }
    }
}
