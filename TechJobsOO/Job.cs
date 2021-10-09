using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        private static string defaultValue(string str)
        {
            return str != null && str != "" ? str : "Data not available";
        }

        public override string ToString()
        {
            if(Name == null && EmployerName == null && EmployerLocation == null && JobType == null && JobCoreCompetency == null)
            {
                return "OOPS! This job does not seem to exist.";
            }

            return $"\nID: {Id}\nName: {defaultValue(Name)}\n Employer: {defaultValue(EmployerName.Value)}\n Location: {defaultValue(EmployerLocation.Value)}\n Position Type: {defaultValue(JobType.Value)}\n Core Competency: {defaultValue(JobCoreCompetency.Value)}\n";
        }
    }
}
