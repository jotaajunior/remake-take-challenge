using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using take.Models;
using take.Services.Interfaces;
using take.Facades.Interfaces;

namespace take.Facades
{
    public class RepositoriesFacade : IRepositoriesFacade
    {
        private readonly IGithubService _githubService;

        public RepositoriesFacade(IGithubService githubService)
        {
            _githubService = githubService;
        }

        /// <summary>
        /// Get the 5 oldest C# repositories
        /// </summary>
        public async Task<IEnumerable<Repository>> GetOldestCsharpRepositories()
        {
            var repositories = await _githubService.GetRepositoriesAsync();

            return repositories.Where(r => r.Language == "C#").Take(5);
        }
    }
}
