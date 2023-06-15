namespace Application.Services.PrizeDrawSubmissions.Submit
{
    public interface IPrizeDrawSubmitService
    {
        Task<ServiceResult> ExecuteAsync(PrizeDrawSubmissionInput input);
    }
}
