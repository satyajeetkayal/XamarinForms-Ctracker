using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CTracker.Models
{
 public class StateData
    {

        [JsonProperty("StateCase")]
        public List<StateCase> StateDatam { get; set; }

    }


    public class StateCase
    {
        [JsonProperty("Active")]
        public int Active { get; set; }
        [JsonProperty("Cured")]
        public int Cured { get; set; }
        [JsonProperty("Deaths")]
        public int Deaths { get; set; }
        [JsonProperty("NoOfCases")]
        public int NoOfCases { get; set; }
        [JsonProperty("State")]
        public string State { get; set; }


    }


}

