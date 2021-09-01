using System.Linq;
using System.Threading.Tasks;

using NSubstitute;
using Xunit;
using Shouldly;

using take.Services.Interfaces;
using take.Facades;
using take.Facades.Interfaces;

namespace take.Tests.Facades
{
    public class RepositoriesFacadeTests
    {
        private readonly IRepositoriesFacade _sut;
        private readonly IGithubService _githubService;

        public RepositoriesFacadeTests()
        {
            _githubService = Substitute.For<IGithubService>();
            _sut = new RepositoriesFacade(_githubService);

            _githubService.GetRepositoriesAsync().Returns(TestsConstants.FakeRepositories);
        }

        [Fact]
        public async Task ShouldReturnListOfRepositories()
        {
            var result = await _sut.GetOldestsCsharpRepositories();

            result.ShouldBe(
                TestsConstants
                    .FakeRepositories
                    .Where(r => r.Language == "C#")
           );
        }
    }
}
