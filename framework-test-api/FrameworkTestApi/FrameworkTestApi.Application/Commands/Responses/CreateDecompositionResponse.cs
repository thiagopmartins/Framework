using FluentValidation.Results;
using FrameworkTestApi.Application.Core.Response;

namespace FrameworkTestApi.Application.Commands.Responses
{
    public class CreateDecompositionResponse : ResponseBase
    {
        public int Number { get; set; }

        public List<int>? Primes{ get; set; }

        public List<int>? Divisors{ get; set; }
    }
}
