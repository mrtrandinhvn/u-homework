using Application.Services.PrizeDrawSubmissions.Read;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    [Authorize(Roles = AppRole.Admin)]
    public class PrizeDrawSubmissionsController : Controller
    {
        private readonly IPrizeDrawSubmissionReadRepository _readRepository;

        public PrizeDrawSubmissionsController(IPrizeDrawSubmissionReadRepository readRepository)
        {
            this._readRepository = readRepository;
        }

        [HttpGet("/prize-draw/submissions")]
        public async Task<IActionResult> Index(GetPaginatedSubmissionsInput input)
        {
            // normalize input
            if (input.Page == 0)
            {
                input.Page = 1;
            }
            
            if (input.PageSize == 0)
            {
                input.PageSize = 10;
            }

            return View(await _readRepository.GetPaginatedResultAsync(input));
        }
    }
}
