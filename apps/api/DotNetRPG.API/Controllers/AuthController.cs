using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetRPG.API.Data;
using DotNetRPG.API.Dtos.User;
using DotNetRPG.API.Models;

namespace DotNetRPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDtoRequest request)
        {
            var response = await _authRepo.Register(
                new User { Username = request.Username}, request.Password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserRegisterDtoRequest request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}