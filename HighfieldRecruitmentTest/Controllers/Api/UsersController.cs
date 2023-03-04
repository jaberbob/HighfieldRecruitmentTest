using HighfieldRecruitmentTest.BL;
using HighfieldRecruitmentTest.Models.Dto;
using HighfieldRecruitmentTest.Models.Entities;
using HighfieldRecruitmentTest.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HighfieldRecruitmentTest.Controllers.Api
{
    /// <summary>
    /// End-points for 'users'
    /// </summary>
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IDataProvider<UserEntity> _userDataProvider;
        private readonly IBusinessLogic<ResponseDto, UserEntity> _recruitementTestBl;

        /// <summary>
        /// Constructor. Takes data provider and business logic
        /// </summary>
        public UsersController(
            IDataProvider<UserEntity> userDataProvider,
            IBusinessLogic<ResponseDto, UserEntity> recruitmentTestBl)
        {
            _userDataProvider = userDataProvider;
            _recruitementTestBl = recruitmentTestBl;
        }

        /// <summary>
        /// Returns a list of all users
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="500">Internal server error - Something went wrong our end.</response>
        /// <returns>List of users</returns>
        [HttpGet]
        [Route("users")]
        [ProducesResponseType(typeof(List<UserEntity>), 200)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = _userDataProvider.GetList();
                return Ok(await users);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Unable to retrieve list of users: {e.Message}");
            }
        }

        /// <summary>
        /// Returns the responseDto as defined in the test
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="500">Internal server error - Something went wrong our end.</response>
        /// <returns>ResponseDto - List of users, favourite colour, age plus twenty years</returns>
        [HttpGet]
        [Route("testResponse")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetTestResponse()
        {
            try
            {
                var users = _userDataProvider.GetList();
                var responseDto = _recruitementTestBl.GenerateResponseModel(await users);

                return Ok(await responseDto);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Unable to retrieve list of users: {e.Message}");
            }
        }
    }
}