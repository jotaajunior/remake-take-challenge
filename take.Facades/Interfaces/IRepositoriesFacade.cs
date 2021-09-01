using System.Collections.Generic;
using System.Threading.Tasks;

using take.Models;

namespace take.Facades.Interfaces
{
    public interface IRepositoriesFacade
    {

        /// <summary>
        /// Get the 5 oldest C# repositories
        /// </summary>
        Task<IEnumerable<Repository>> GetOldesCsharpRepositories();
    }
}
