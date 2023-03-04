using HighfieldRecruitmentTest.Models.Entities;

namespace HighfieldRecruitmentTest.Repos
{
    /// <summary>
    /// Users data accessor
    /// </summary>
    public class UserRepo : IDataProvider<UserEntity>
    {
        /// <summary>
        /// Get list of users
        /// </summary>
        async Task<List<UserEntity>> IDataProvider<UserEntity>.GetList()
        {
            using (var httpClient = new HttpClient())
            {
                var customerData = await httpClient.GetFromJsonAsync<List<UserEntity>>(
                    "https://recruitment.highfieldqualifications.com/api/test");

                return await Task.FromResult(customerData ?? new List<UserEntity>());
            }
        }
    }
}
