using HighfieldRecruitmentTest.Models.Entities;

namespace HighfieldRecruitmentTest.Models.Dto
{
    /// <summary>
    /// Requested data for HighfieldRecruitmentTest
    /// </summary>
    public class ResponseDto
    {
        /// <summary>
        /// List of UserEntity
        /// </summary>
        public List<UserEntity>? Users { get; set; }

        /// <summary>
        /// List of AgePlusTwentyDto
        /// </summary>
        public List<AgePlusTwentyDto>? Ages { get; set; }

        /// <summary>
        /// List of TopColoursDto
        /// </summary>
        public List<TopColoursDto>? TopColours { get; set; }
    }
}
