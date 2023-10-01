using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetDapperExample.Models;
using NetDapperExample.Services;

namespace NetDapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateNewUser([FromBody] UserModel entity)
        {
            await _unitOfWork.UserService.CreateNewUser(entity);

            return Ok(new { isSuccess = true, statusCode = StatusCodes.Status200OK, message = "Success create user" });
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var res = await _unitOfWork.UserService.GetUserById(id);

            return Ok(new { isSuccess = true, statusCode = StatusCodes.Status200OK, message = "Success get user", data = res });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllUser()
        {
            var res = await _unitOfWork.UserService.GetAllUser();

            return Ok(new { isSuccess = true, statusCode = StatusCodes.Status200OK, message = "Success get all user", data = res });
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            await _unitOfWork.UserService.DeleteUserById(id);

            return Ok(new { isSuccess = true, statusCode = StatusCodes.Status200OK, message = "Success delete user" });
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> UpdateUser(UserModel entity)
        {
            await _unitOfWork.UserService.UpdateUser(entity);

            return Ok(new { isSuccess = true, statusCode = StatusCodes.Status200OK, message = "Success update user" });
        }
    }
}
