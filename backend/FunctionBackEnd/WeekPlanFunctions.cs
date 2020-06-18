using System;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServerlessSample.FunctionBackEnd.Services;
using ServerlessSample.FunctionBackEnd.Models;

namespace ServerlessSample.FunctionBackEnd
{
    public static class WeekPlanFunctions
    {
        [FunctionName("GetWeekPlans")]
        public static async Task<IActionResult> GetWeekPlans([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "weekplans")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetWeekPlans triggered....");
            try
            {
                var persistenceService = ServiceFactory.GetPersistenceService();
                var plans = await persistenceService.GetWeekPlansAsync();

                if (plans == null && !plans.Any())
                    return new NotFoundResult();

                return (ActionResult) new OkObjectResult(plans);
            }
            catch (Exception e)
            {
                var error = $"GetWeekPlans failed: {e.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("GetWeekPlan")]
        public static async Task<IActionResult> GetWeekPlan([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "weekplans/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("GetWeekPlan triggered....");

            try
            {
                var persistenceService = ServiceFactory.GetPersistenceService();
                return (ActionResult)new OkObjectResult(await persistenceService.GetWeekPlanAsync(id));
            }
            catch (Exception e)
            {
                var error = $"GetWeekPlan failed: {e.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("CreateWeekPlan")]
        public static async Task<IActionResult> CreateWeekPlan([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "weekplans")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("CreateWeekPlan triggered....");
            var persistenceService = ServiceFactory.GetPersistenceService();
            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                WeekPlan plan = JsonConvert.DeserializeObject<WeekPlan>(requestBody);
                return (ActionResult)new OkObjectResult(await persistenceService.AddWeekPlanAsync(plan));
            }
            catch (Exception e)
            {
                var error = $"CreateWeekPlan failed: {e.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("UpdateWeekPlan")]
        public static async Task<IActionResult> UpdateWeekPlan([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "weekplans")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("UpdateWeekPlan triggered....");
            var persistenceService = ServiceFactory.GetPersistenceService();
            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                WeekPlan plan = JsonConvert.DeserializeObject<WeekPlan>(requestBody);

                return (ActionResult)new OkObjectResult(await persistenceService.UpdateWeekPlanAsync(plan.Id, plan));
            }
            catch (Exception e)
            {
                var error = $"UpdateWeekPlan failed: {e.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("DeleteWeekPlan")]
        public static async Task<IActionResult> DeleteWeekPlan([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "weekplans/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("DeleteWeekPlan triggered....");

            try
            {
                var persistenceService = ServiceFactory.GetPersistenceService();
                await persistenceService.DeleteWeekPlanAsync(id);
                return (ActionResult)new OkObjectResult("Ok");
            }
            catch (Exception e)
            {
                var error = $"DeleteWeekPlan failed: {e.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }
        }
    }
}
