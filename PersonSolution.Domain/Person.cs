using System;

namespace PersonSolution.Domain
{
    public class Person : BusinessObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalN { get; set; }
        public DateTime BirthDate { get; set; }
        //[ForeignKey(nameof(SexId))]
        public Sex Sex { get; set; }
        public int SexId { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Active = 0,
        Passive = 1
    }
}
