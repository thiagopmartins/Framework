using FrameworkTestApi.Application.Commands.Responses;
using MediatR;

namespace FrameworkTestApi.Application.Commands.Requests
{
    public class CreateDecompositionRequest : IRequest<CreateDecompositionResponse>
    {
        public int Number { get; set; }

        public CreateDecompositionRequest(int number)
        {
            Number = number;
        }

    }
}
