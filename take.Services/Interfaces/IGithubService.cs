using System.Collections.Generic;
using System.Threading.Tasks;

using take.Models;

using RestEase;

namespace take.Services.Interfaces
{
    /// <summary>
    /// Interface for communicating with Github API.
    /// </summary>
    [Header("User-Agent", "RestEase")]
    public interface IGithubService
    {
        /// <summary>
        /// List of repositories
        /// </summary>
        [Get("/repos?sort=created&direction=asc")]
        Task<List<Repository>> GetRepositoriesAsync();
    }
}
