namespace Application.Services.PrizeDrawSubmissions.Submit
{
    /// <summary>
    /// This service handle the form submit action. It should also contains user input validation logic.
    /// </summary>
    public interface IPrizeDrawSubmitService
    {
        /// <summary>
        /// Validate the input and save the data to persistence layer if the input is valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> ExecuteAsync(PrizeDrawSubmissionInput input);
    }
}
