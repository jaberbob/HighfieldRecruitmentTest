namespace HighfieldRecruitmentTest.Tests.Repos
{
    internal class UsersRepoTests : Tests
    {
        [Test]
        public void GetUserList()
        {
            var result = UserRepo.GetList().Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result[0].Id);
        }
    }
}
