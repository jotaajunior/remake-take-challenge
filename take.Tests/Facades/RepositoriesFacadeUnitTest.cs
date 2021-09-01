using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NSubstitute;
using Xunit;
using Shouldly;

using take.Models;
using take.Services.Interfaces;
using take.Facades;
using take.Facades.Interfaces;

namespace take.Tests.Facades
{
    public class RepositoriesFacadeUnitTest
    {
        private readonly IRepositoriesFacade _repositoriesFacade;
        private readonly IGithubService _githubService;

        public static List<Repository> fakeRepositories = new List<Repository>
            {
                new Repository()
                {
                    Name = "1 C#",
                    Language = "C#"
                },

                new Repository()
                {
                    Name = "Should be ignored",
                    Language = "JavaScript"
                },

                new Repository()
                {
                    Name = "2 C#",
                    Language = "C#"
                },

                new Repository()
                {
                    Name = "3 C#",
                    Language = "C#"
                },

                new Repository()
                {
                    Name = "Should be ignored"
                },

                new Repository()
                {
                    Name = "4 C#",
                    Language = "C#"
                },

                new Repository()
                {
                    Name = "C++",
                    Language = "C++"
                },

                new Repository()
                {
                    Name = "Not C#",
                    Language = "Elixir"
                },

                new Repository()
                {
                    Name = "5 C#",
                    Language = "C#"
                }
            };

        public RepositoriesFacadeUnitTest()
        {
            _githubService = Substitute.For<IGithubService>();
            _repositoriesFacade = new RepositoriesFacade(_githubService);

            _githubService.GetRepositoriesAsync().Returns(fakeRepositories);
        }

        [Fact]
        public async Task ShouldReturnOnlyCsharpRepositories()
        {
            var result = await _repositoriesFacade.GetOldestsCsharpRepositories();

            result.ShouldBe(fakeRepositories.Where(r => r.Language == "C#"));
        }
    }
}
