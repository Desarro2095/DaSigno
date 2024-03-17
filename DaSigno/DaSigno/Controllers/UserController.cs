using DaSigno.BM.Users;
using DaSigno.DT.Response;
using DaSigno.DT.Users;
using DaSigno.SP.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaSigno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: Controller
    {
        private readonly IBMUser bMUser;
        public UserController(IBMUser bMUser)
        {
            this.bMUser = bMUser;
        }

        [HttpPost("CreateUser")]
        public ActionResult<ResponseDTO<bool>> CreateUser(UserDTO user)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<bool> result = this.bMUser.CreateUser(user);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpDelete("DeleteUser")]
        public ActionResult<ResponseDTO<bool>> DeleteUser(int userId)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<bool> result = this.bMUser.DeleteUser(userId);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("GetUserById")]
        public ActionResult<ResponseDTO<UserDTO>> GetUserById(int userId)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<UserDTO> result = this.bMUser.GetUserById(userId);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("GetUserByName")]
        public ActionResult<ResponseDTO<List<UserDTO>>> GetUserByName(string firstName = null, string lastName = null, int pagination = 1)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<List<UserDTO>> result = this.bMUser.GetUserByName(firstName, lastName, pagination);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("GetUsers")]
        public ActionResult<ResponseDTO<List<UserDTO>>> GetUsers()
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<List<UserDTO>> result = this.bMUser.GetUsers();
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("UpdateUser")]
        public ActionResult<ResponseDTO<UserDTO>> UpdateUser(UserDTO user)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<UserDTO> result = this.bMUser.UpdateUser(user);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }
    }
}
