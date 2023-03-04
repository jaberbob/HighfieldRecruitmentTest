namespace HighfieldRecruitmentTest.Models.Dto
{
    /// <summary>
    /// Dto - For age plus twenty years calculation
    /// </summary>
    public class AgePlusTwentyDto
    {
        /// <summary>
        /// Unique ID of user
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Original age (calculated from DOB) of user
        /// </summary>
        public int OriginalAge { get; set; }

        /// <summary>
        /// Age plus twenty years (calculated from DOB and adding twenty to years DT)
        /// </summary>
        public int AgePlusTwenty { get; set; }
    }
}
