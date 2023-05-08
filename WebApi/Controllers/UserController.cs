using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Ctor

        private readonly IApiRepository _apiRepository;
        public UserController(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = new User
            {
                Name = user.Name,
            };

            _apiRepository.AddUser(result);
            await _apiRepository.SaveChange();

            return Ok(result);
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _apiRepository.GetAllUsers();

            return Ok(result);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _apiRepository.GetUserById(id);

            return Ok(result);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(User user, int id)
        {
            var result = await _apiRepository.GetUserById(id);

            result.Name = user.Name;

            //_apiRepository.UpdateUser(user);
            await _apiRepository.SaveChange();

            return Ok();
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _apiRepository.GetUserById(id);

            _apiRepository.DeleteUser(result);
            await _apiRepository.SaveChange();

            return Ok();
        }

    }
}
