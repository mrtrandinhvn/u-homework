namespace Infrastructure.Caching
{
    public interface IDataAccessCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns>Null if cache key does not exist.</returns>
        Task<T?> GetAsync<T>(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>True if success.</returns>
        Task<bool> SetAsync(string key, object value, TimeSpan? timeout = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if success.</returns>
        Task<bool> DeleteAsync(string key);
    }
}
