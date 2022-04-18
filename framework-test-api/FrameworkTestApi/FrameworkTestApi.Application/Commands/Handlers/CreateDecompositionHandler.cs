using FrameworkTestApi.Application.Commands.Requests;
using FrameworkTestApi.Application.Commands.Responses;
using MediatR;
using System.Linq;

namespace FrameworkTestApi.Application.Handlers
{
    public class CreateDecompositionHandler : IRequestHandler<CreateDecompositionRequest, CreateDecompositionResponse>
    {
        public Task<CreateDecompositionResponse> Handle(CreateDecompositionRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateDecompositionResponse();
           
            if (request == null)
            {
                result.AddError("Error: Request is null");

                return Task.FromResult(result);
            }

            try
            {
                result.Number = request.Number;
                result.Divisors = GetDivisorsNumber(request.Number);
                result.Primes = GetPrimesNumberOfDivisors(result.Divisors);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return Task.FromResult(result);
        }

        #region Métodos Auxiliares

        private List<int> GetDivisorsNumber(int number)
        {
            var divisors = new List<int>();

            for(int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            };

            return divisors;
        }

        private List<int> GetPrimesNumberOfDivisors(List<int> divisors)
        {
            var primes = new List<int>();

            foreach (var divisor in divisors)
            {
                if (IsPrimeNumber(divisor))
                {
                    primes.Add(divisor);
                }
            };

            return primes;
        }

        private bool IsPrimeNumber(int number)
        {
            return GetDivisorsNumber(number).Count() <= 2;
        }

        #endregion
    }
}
