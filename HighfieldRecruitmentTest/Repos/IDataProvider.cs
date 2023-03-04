namespace HighfieldRecruitmentTest.Repos
{
    /// <summary>
    /// Basic business data provider interface
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public interface IDataProvider<T>
    {
        /// <summary>
        /// Generate model
        /// </summary>
        Task<List<T>> GetList();
    }
}
