using System;
using Newtonsoft.Json;

namespace ServerlessSample.FunctionBackEnd.Models
{
    public class WeekPlan
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "goals")]
        public string Goals { get; set; }

        [JsonProperty(PropertyName = "tasks")]
        public string Tasks { get; set; }

        public WeekPlan()
        {
            //Assign a new GUID to the Id
            Id = Guid.NewGuid().ToString();
        }
    }
}