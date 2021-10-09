using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job job1;
        Job job2;
        Job job3;
        Job job4;

        [TestInitialize]
        public void CreateJobObjects()
        {
            job1 = new Job();
            job2 = new Job();
            job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsTrue(job1.Id != job2.Id && (job1.Id + 1) == job2.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(job3.Name == "Product tester");
            Assert.IsTrue(job3.EmployerName.Value == "ACME");
            Assert.IsTrue(job3.EmployerLocation.Value == "Desert");
            Assert.IsTrue(job3.JobType.Value == "Quality control");
            Assert.IsTrue(job3.JobCoreCompetency.Value == "Persistence");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4));
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string testOutput = $"\nID: {job3.Id}\nName: {job3.Name}\n Employer: {job3.EmployerName.Value}\n Location: {job3.EmployerLocation.Value}\n Position Type: {job3.JobType.Value}\n Core Competency: {job3.JobCoreCompetency.Value}\n";
            Assert.AreEqual(testOutput, job3.ToString());
        }

        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            job3.EmployerName.Value = "";
            job3.JobType.Value = "";
            string testOutput = $"\nID: {job3.Id}\nName: {job3.Name}\n Employer: Data not available\n Location: {job3.EmployerLocation.Value}\n Position Type: Data not available\n Core Competency: {job3.JobCoreCompetency.Value}\n";

            Assert.AreEqual(testOutput, job3.ToString());
        }

        [TestMethod]
        public void TestToStringNonExistingJob()
        {
            Assert.AreEqual("OOPS! This job does not seem to exist.", job1.ToString());
        }
    }
}
