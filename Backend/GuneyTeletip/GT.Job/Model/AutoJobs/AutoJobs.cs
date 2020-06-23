using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.Job.Implementation;
using GT.TeletipKos;
using GT.UTILS.GRID;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Util.Job;

namespace GT.Job.Model.AutoJobs
{
    public static class AutoJobs
    {
        public static BackgroundJobItem SendKos { get; set; }
        public static BackgroundJobItem MakeKos { get; set; }
        public static BackgroundJobItem STMMatch { get; set; }

        static AutoJobs()
        {
            MakeKos = new BackgroundJobItem(o =>
            {
                var mc = new MakeKosJob();
                mc.DoSingleBatch(o);
            });
            SendKos = new BackgroundJobItem(null);
            STMMatch = new BackgroundJobItem(null);
        }


    }
}


