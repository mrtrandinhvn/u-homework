using Application.Services;
using Application.Services.PrizeDrawSubmissions.Submit;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Website.Models;

namespace Website.Controllers
{
    [ApiController]
    public class SubmitPrizeDrawController : Controller
    {
        private readonly IPrizeDrawSubmitService _submitService;
        private readonly IMapper _mapper;

        public SubmitPrizeDrawController(
            IPrizeDrawSubmitService submitService,
            IMapper mapper)
        {
            this._submitService = submitService;
            this._mapper = mapper;
        }

        [HttpPost("prize-draw/submit")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SubmitAsync([FromForm] PrizeDrawSubmissionRequest data)
        {
            ServiceResult result = await _submitService.ExecuteAsync(_mapper.Map<PrizeDrawSubmissionInput>(data));
            if (result.ValidationResult.Any())
            {
                return BadRequest(result);
            }
            else
            {
                return result.Success
                    ? Ok(result)
                    : StatusCode(StatusCodes.Status422UnprocessableEntity, result);
            }
        }
    }
}
