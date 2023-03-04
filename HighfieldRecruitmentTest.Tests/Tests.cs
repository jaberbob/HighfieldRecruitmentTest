using HighfieldRecruitmentTest.BL;
using HighfieldRecruitmentTest.Controllers.Api;
using HighfieldRecruitmentTest.Models.Dto;
using HighfieldRecruitmentTest.Models.Entities;
using HighfieldRecruitmentTest.Repos;

namespace HighfieldRecruitmentTest.Tests
{
    [TestFixture]
    public class Tests
    {
        protected IDataProvider<UserEntity> UserRepo { get; private set; }
        protected IBusinessLogic<ResponseDto, UserEntity> RecruitmentTestBl { get; private set; }
        protected UsersController UsersController { get; private set; }


        [OneTimeSetUp]
        public void TestSetup()
        {
            UserRepo = new UserRepo();
            RecruitmentTestBl = new RecruitmentTestBl();
            UsersController = new UsersController(UserRepo, RecruitmentTestBl);
        }
    }
}