using GT.BAL.TeletipKos;
using GT.SERVICE;
using NUnit.Framework;

namespace GT.BAL.Test
{
    /// <summary>
    /// UC1 Infinity Entegrasyon 
    /// </summary>
    public class TEST_UC7_2
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void UC7_2()
        {
            long[] studyIDList = new long[] { 920525, 920524 };
            StudyKosService sk = new StudyKosService(new BussinessContext(new UserContextModel(0)));

            DataService.Model.KosStudyFilter filter = new DataService.Model.KosStudyFilter() { StudyIDList = studyIDList };
            UTILS.GRID.Gridable<DataService.Model.KosStudyFilter> gridFilter = new UTILS.GRID.Gridable<DataService.Model.KosStudyFilter>() { Filter = filter };
            System.Collections.Generic.IEnumerable<Job.Implementation.OperationResult<Job.Implementation.ReprocessStudyOperationResult>> res = sk.ReProcessKos(gridFilter);


        }



    }
}