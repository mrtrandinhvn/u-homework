namespace Application.Services
{
    public class ServiceResult
    {
        public IDictionary<string, string[]> ValidationResult { get; set; } = new Dictionary<string, string[]>();
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class ServiceResult<T> : ServiceResult where T : class
    {
        public T? Data { get; set; }

        public ServiceResult()
        {
        }

        /// <summary>
        /// Construct a success result.
        /// </summary>
        /// <param name="data"></param>
        public ServiceResult(T data)
        {
            Data = data;
            Success = true;
        }
    }
}
