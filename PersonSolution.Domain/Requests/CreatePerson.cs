using System;

namespace PersonSolution.Domain.Requests
{
    public class PersonDto 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalN { get; set; }
        public DateTime BirthDate { get; set; }
        public int SexId { get; set; }
        public Status Status { get; set; }
    }

    public class UpdatePersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalN { get; set; }
        public DateTime BirthDate { get; set; }
        public int SexId { get; set; }
        public Status Status { get; set; }

    }
}
