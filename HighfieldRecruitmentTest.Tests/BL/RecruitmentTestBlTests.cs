namespace HighfieldRecruitmentTest.Tests.Bl
{
    internal class RecruitmentTestBlTests : Tests
    {
        [Test]
        public void GetUserList()
        {
            var userList = UserRepo.GetList().Result;
            var result = RecruitmentTestBl.GenerateResponseModel(userList).Result;

            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Users);
            Assert.IsTrue(result.Users.Count > 0);

            Assert.IsNotNull(result.TopColours);
            Assert.IsNotNull(result.TopColours.Count > 0);

            Assert.IsNotNull(result.Ages);
            Assert.IsNotNull(result.TopColours.Count > 0);
        }

        [Test]
        public void TopColoursOrderedCorrectly()
        {
            var userList = UserRepo.GetList().Result;
            var result = RecruitmentTestBl.GenerateResponseModel(userList).Result;

            Assert.IsNotNull(result);

            Assert.IsNotNull(result.TopColours);
            Assert.IsNotNull(result.TopColours.Count > 0);

            // Highest count to top:

            Assert.IsTrue(result.TopColours[0].Count > result.TopColours[result.TopColours.Count - 1].Count);

            // Alphabetic order:

            for (int i = 0; i < result.TopColours.Count(); i++)
            {
                if (result.TopColours[i].Count == result.TopColours[i + 1].Count)
                {
                    if (result.TopColours[i]?.Colour != null && result.TopColours[i + 1]?.Colour != null)
                    {
#pragma warning disable CS8604 // Possible null reference argument.

                        var list1 = new List<string> { result.TopColours[i].Colour ?? null, result.TopColours[i + 1].Colour };
                        var list2 = new List<string> { result.TopColours[i + 1].Colour ?? null, result.TopColours[i].Colour };
                        list2.Sort();

                        Assert.IsTrue(list1[0] == list2[0]);
                        return;

#pragma warning restore CS8604 // Possible null reference argument.
                    }
                    else
                        Assert.Fail();
                }
            }
        }

        [Test]
        public void AgesPlusTwentyCorrect()
        {
            var userList = UserRepo.GetList().Result;
            var result = RecruitmentTestBl.GenerateResponseModel(userList).Result;

            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Ages);
            Assert.IsNotNull(result.Ages.Count > 0);

            // Take a sample
            for (int i = 0; i < 6; i++)
            {
                Assert.IsTrue(result.Ages[i].AgePlusTwenty == (result.Ages[i].OriginalAge + 20));
            }
        }
    }
}