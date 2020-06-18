using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerlessSample.FunctionBackEnd.Models;

namespace ServerlessSample.FunctionBackEnd.Services
{
    public class FakePersistenceService : IPersistenceService
    {
        public async Task<IEnumerable<WeekPlan>> GetWeekPlansAsync(string queryString = "")
        {
            var task = Task.Run(() => GetFakeData());
            return await task;
        }

        public async Task<WeekPlan> GetWeekPlanAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<WeekPlan> AddWeekPlanAsync(WeekPlan weekPlan)
        {
            throw new NotImplementedException();
        }

        public async Task<WeekPlan> UpdateWeekPlanAsync(string id, WeekPlan weekPlan)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWeekPlanAsync(string id)
        {
            throw new NotImplementedException();
        }

        private static List<WeekPlan> GetFakeData()
        {
            var lst = new List<WeekPlan>{
                new WeekPlan
                {
                    Title = "Week 1 (fake data)",
                    StartDate = DateTime.Today.AddDays(7),
                    Goals = "Complete System analysis",
                    Tasks = "Meet with clients; document requirements"
                },
                new WeekPlan
                {
                    Title = "Week 2 (fake data)",
                    StartDate = DateTime.Today.AddDays(14),
                    Goals = "Complete UI Proposal",
                    Tasks = "Design UI mockup and work flow; gather initial feedback"
                }
            };
            return lst;
        }

    }
}
