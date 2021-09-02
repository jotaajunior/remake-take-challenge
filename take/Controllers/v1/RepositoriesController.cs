using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using take.Facades.Interfaces;

namespace take.Controllers
{
    /// <summary>
    /// Controller responsible for getting repositories
    /// </summary>
    [ApiController]
    [Route("api/v1/repos")]
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesFacade _repositoriesFacade;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoriesFacade"></param>
        public RepositoriesController(IRepositoriesFacade repositoriesFacade)
        {
            _repositoriesFacade = repositoriesFacade;
        }

        /// <summary>
        /// Returns a list containing the 5 oldest C# repositories.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var repositories = await _repositoriesFacade.GetOldestCsharpRepositories();

            return Ok(repositories);
        }
    }
}
