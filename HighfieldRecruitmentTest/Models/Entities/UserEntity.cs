namespace HighfieldRecruitmentTest.Models.Entities
{
    /// <summary>
    /// User list as fetch from - https://recruitment.highfieldqualifications.com/api/test
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Unique ID of user
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// User's forename
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// User's surname
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// User's date of birth
        /// </summary>
        public DateTime Dob { get; set; }

        /// <summary>
        /// User's favourite colour
        /// </summary>
        public string? FavouriteColour { get; set; }
    }
}
