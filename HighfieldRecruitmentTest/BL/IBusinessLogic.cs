namespace HighfieldRecruitmentTest.BL
{
    /// <summary>
    /// Business logic interface
    /// </summary>
    public interface IBusinessLogic<T, U>
    {
        /// <summary>
        /// Generate model
        /// </summary>
        Task<T> GenerateResponseModel(List<U> entity);
    }
}
