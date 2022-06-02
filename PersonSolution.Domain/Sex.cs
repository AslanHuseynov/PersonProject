using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PersonSolution.Domain
{
    public class Sex : BusinessObject
    {
        public SexType Value { get; set; }
        [JsonIgnore]
        public List<Person> Persons { get; set; }
    }


    public enum SexType
    {
        Male =0,
        Female = 1,
    }
}
