using FrameworkTestApi.Application.Commands.Requests;
using FrameworkTestApi.Application.Handlers;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace FrameworkTestApi.Application.Test
{
    public class CreateDecompositionHandlerTest
    {


        [Fact]
        public async void Deve_Gerar_Uma_Decomposicao_Valida()
        {
            int _inputTestValue = 45;
            List<int> _divisorsTestResult = new List<int> { 1, 3, 5, 9, 15, 45 };
            List<int> _primesTestResult = new List<int> { 1, 3, 5 };

            var request = new CreateDecompositionRequest(_inputTestValue);
            var result = await new CreateDecompositionHandler().Handle(request, CancellationToken.None);

            result.ValidationResult.Errors.Count.ShouldBe(0);
            result.Divisors.ShouldBe(_divisorsTestResult);
            result.Primes.ShouldBe(_primesTestResult);
            result.Number.ShouldBe(_inputTestValue);
        }

        [Fact]
        public async void Nao_Deve_Gerar_Uma_Decomposicao_Valida_Se_Houver_Excecao()
        {
            var result = await new CreateDecompositionHandler().Handle(null, CancellationToken.None);
            
            result.ValidationResult.Errors.Count.ShouldNotBe(0);
        }
    }
}