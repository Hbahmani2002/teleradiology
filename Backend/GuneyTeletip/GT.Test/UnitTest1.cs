using GT.Data.Service.Implementation;
using GT.Repository.infinity.Model.Filter;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
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
            Gridable<StudyViewFilter> gri = new Gridable<StudyViewFilter>();
            StudyViewFilter filter = new StudyViewFilter();
            filter.AccessNo = "100";
            gri.Filter = filter;
            var list = service.GetStudyList(gri);
        }
    }
}