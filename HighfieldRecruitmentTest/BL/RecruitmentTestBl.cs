using AgeCalculator;
using HighfieldRecruitmentTest.Models.Dto;
using HighfieldRecruitmentTest.Models.Entities;

namespace HighfieldRecruitmentTest.BL
{
    /// <summary>
    /// Business logic for HighfieldRecruitmentTest
    /// </summary>
    public class RecruitmentTestBl : IBusinessLogic<ResponseDto, UserEntity>
    {
        /// <summary>
        /// Get the ResponseDto model with the calculated objects for the results of the HighfieldRecruitmentTest
        /// </summary>
        /// <param name="userList">User list from https://recruitment.highfieldqualifications.com/api/test</param>
        /// <returns>List of UserEntity objects</returns>
        async Task<ResponseDto> IBusinessLogic<ResponseDto, UserEntity>.GenerateResponseModel(List<UserEntity> userList)
        {
            var response = new ResponseDto
            {
                Users = userList,
                TopColours = CalculateFavouriteColours(userList),
                Ages = CalculateAgePlus20Years(userList)
            };

            return await Task.FromResult(response);
        }

        private List<TopColoursDto> CalculateFavouriteColours(List<UserEntity> userList)
        {
            var favouriteColours = new List<TopColoursDto>();
            foreach (var distinctColour in userList.Select(c => c.FavouriteColour).Distinct())
            {
                favouriteColours.Add(new TopColoursDto
                {
                    Colour = distinctColour,
                    Count = userList.Where(f => f.FavouriteColour == distinctColour).Count()
                });
            }

            return
                favouriteColours.OrderByDescending(c => c.Count)
                                .ThenBy(a => a.Colour)
                                .ToList();
        }

        private List<AgePlusTwentyDto> CalculateAgePlus20Years(List<UserEntity> userList)
        {
            var agePlus20 = new List<AgePlusTwentyDto>();
            foreach (var user in userList)
            {
                agePlus20.Add(new AgePlusTwentyDto
                {
                    UserId = user.Id,
                    OriginalAge = new Age(user.Dob, DateTime.Today).Years,
                    AgePlusTwenty = new Age(user.Dob, DateTime.Today).Years + 20
                });
            }

            return agePlus20;
        }
    }
}
