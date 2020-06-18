using System.Collections.Generic;
using System.Threading.Tasks;
using ServerlessSample.FunctionBackEnd.Models;

namespace ServerlessSample.FunctionBackEnd.Services
{
    public interface IPersistenceService
    {
        Task<IEnumerable<WeekPlan>> GetWeekPlansAsync(string query = "");
        Task<WeekPlan> GetWeekPlanAsync(string id);
        Task<WeekPlan> AddWeekPlanAsync(WeekPlan weekPlan);
        Task<WeekPlan> UpdateWeekPlanAsync(string id, WeekPlan weekPlan);
        Task DeleteWeekPlanAsync(string id);
    }
}
