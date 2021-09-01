using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using take.Controllers;
using take.Facades.Interfaces;

using Shouldly;
using NSubstitute;

using Xunit;

namespace take.Tests.Controllers.v1
{
    public class RepositoriesControllerTests
    {
        private readonly RepositoriesController _sut;
        private readonly IRepositoriesFacade _repositoriesFacade;
        
        public RepositoriesControllerTests()
        {
            _repositoriesFacade = Substitute.For<IRepositoriesFacade>();
            _sut = new RepositoriesController(_repositoriesFacade);
        }

        [Fact]
        public async Task IndexShouldReturnOkObject()
        {
            var result = await _sut.Index();

            result.ShouldBeOfType<OkObjectResult>();
        }
    }
}
