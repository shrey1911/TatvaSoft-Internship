using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Services;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUserController(IAdminUserService _adminUserService) : Controller
    {
        [HttpGet]
        [Route("UserDetailList")]
        public ActionResult UserDetailList()
        {
            try
            {
                var res = _adminUserService.UserDetailsList();
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get user list" });
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser([FromQuery] int id)
        {
            try
            {
                var res = _adminUserService.UserDelete(id);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user" });
            }
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] User user) // Change return type to Task<ActionResult>
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult
                {
                    Data = null,
                    Result = ResponseStatus.Error,
                    Message = "Invalid user data"
                });
            }

            try
            {
                var res = await _adminUserService.AddUser(user);

                return Ok(new ResponseResult
                {
                    Data = res,
                    Result = ResponseStatus.Success,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult
                {
                    Data = null,
                    Result = ResponseStatus.Error,
                    Message = "Failed to add user"
                });
            }
        }
    }
}
