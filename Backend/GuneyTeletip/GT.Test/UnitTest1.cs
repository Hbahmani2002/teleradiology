using GT.Data.Service.Implementation;
using MEDLIFE.SERVICE;
using NUnit.Framework;

namespace GT.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        StudyDataService service = new StudyDataService(new BussinessContext(new UserContextModel(1, null)));
        [Test]
        public void Test1()
        {
            var list = service.GetStudyList();
        }
    }
}