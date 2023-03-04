using HighfieldRecruitmentTest.Models.Dto;
using HighfieldRecruitmentTest.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HighfieldRecruitmentTest.Tests.Controllers
{
    internal class UsersControllerTests : Tests
    {
        [Test]
        public void GetUserList()
        {
            var result = UsersController.GetUsers().Result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsNotNull(result.Value);
            Assert.IsTrue(((List<UserEntity>)result.Value).Count > 0);
        }

        [Test]
        public void GetTestResponse()
        {
            var result = UsersController.GetTestResponse().Result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsNotNull(result.Value);

            Assert.IsNotNull(((ResponseDto)result.Value).Users);
            Assert.IsTrue(((ResponseDto)result.Value).Users.Count > 0);

            Assert.IsNotNull(((ResponseDto)result.Value).TopColours);
            Assert.IsTrue(((ResponseDto)result.Value).TopColours.Count > 0);

            Assert.IsNotNull(((ResponseDto)result.Value).Ages);
            Assert.IsTrue(((ResponseDto)result.Value).Ages.Count > 0);
        }
    }
}
