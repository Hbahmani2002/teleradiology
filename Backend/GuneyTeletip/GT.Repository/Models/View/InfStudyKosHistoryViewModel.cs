using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class InfStudyKosHistoryViewModel : BaseTableViewModel
    {

        [DataEntityID]
        public long ID { get; set; }
        public string Description { get; set; }
        public long StudyID { get; set; }

    }
}
