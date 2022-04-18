using FluentValidation.Results;
using FrameworkTestApi.Application.Commands.Requests;
using FrameworkTestApi.Application.Commands.Responses;
using FrameworkTestApi.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FrameworkTestApi.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class DecompositionController : MainController
    {
        private readonly IMediator _mediator;

        public DecompositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]     
        [ProducesResponseType(typeof(CreateDecompositionResponse), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        public async Task<IActionResult> Create(CreateDecompositionModelRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _mediator.Send(request: new CreateDecompositionRequest(request.Number));

            return CustomResponse(result);
        }
    }
}
