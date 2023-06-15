using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Services.PrizeDrawSubmissions.Submit
{
    public class PrizeDrawSubmitService : IPrizeDrawSubmitService
    {
        private readonly ILogger<PrizeDrawSubmitService> _logger;
        private readonly IValidator<PrizeDrawSubmissionInput> _validator;
        private readonly IPrizeDrawSubmissionReadWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public PrizeDrawSubmitService(
            ILogger<PrizeDrawSubmitService> logger,
            IValidator<PrizeDrawSubmissionInput> validator,
            IPrizeDrawSubmissionReadWriteRepository writeRepository,
            IMapper mapper)
        {
            this._logger = logger;
            this._validator = validator;
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }
        public async Task<ServiceResult> ExecuteAsync(PrizeDrawSubmissionInput input)
        {
            _logger.LogInformation("Begin PrizeDrawSubmitService");
            ValidationResult result = await _validator.ValidateAsync(input);
            if (!result.IsValid)
            {
                return new ServiceResult
                {
                    ValidationResult = result.ToDictionary(),
                };
            }

            _logger.LogInformation("Input is valid, begin saving data to database");
            bool isSuccess = await _writeRepository.AddAsync(_mapper.Map<ProductPrizeDrawSubmission>(input));
            return new ServiceResult
            {
                Success = isSuccess,
            };
        }
    }
}
