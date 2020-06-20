using GT.TeletipKos.Model;
using KOS.TeletipKos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Util.Logger;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class MultiKosOperationManager
    {
        public ILogger Logger { get; }
        public TeletipKosService TeletipKosService { get; }

        public MultiKosOperationManager(ILogger logger, TeletipKosServiceSettings settings)
        {
            this.Logger = logger;
            this.TeletipKosService = new TeletipKosService(settings);
        }

        public bool SendKos(IEnumerable<SendKosParameter> items, int maxDegreeOfParallelism = 10)
        {
            return ThreadManager.QueueUserWorkItem(o => GetSendKosTask(items, maxDegreeOfParallelism));
        }
        private void SendKos(SendKosParameter item)
        {
            var res = this.TeletipKosService.SendKos(item);
            Logger.LogInfo($"{res.IsSuccess}\t{res.Message}\t{item.KosFilePath}\t{res.Arguments}");
        }

        private void GetSendKosTask(IEnumerable<SendKosParameter> items, int maxDegreeOfParallelism)
        {
            Logger.LogInfo("START");
            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }, SendKos);
            Logger.LogInfo("END");
        }

        public bool MakeKos(IEnumerable<MakeKosParameter> items, int maxDegreeOfParallelism = 10)
        {
            return ThreadManager.QueueUserWorkItem(o => GetMakeKosTask(items, maxDegreeOfParallelism));
        }

        private void GetMakeKosTask(IEnumerable<MakeKosParameter> items, int maxDegreeOfParallelism)
        {
            Logger.LogInfo("START");
            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }, MakeKos);
            Logger.LogInfo("END");
        }

        private void MakeKos(MakeKosParameter item)
        {
            var res = this.TeletipKosService.MakeKos(item);
            Logger.LogInfo($"{res.IsSuccess}\t{res.Message}\t{item.AccessionNumber}\t{item.OutputKosFilePath}\t{res.Arguments}");
        }
    }
}
