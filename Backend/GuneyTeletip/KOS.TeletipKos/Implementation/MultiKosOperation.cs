using GT.TeletipKos.Model;
using System.Collections.Generic;
using Util.Logger;

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

        public void SendKos(IEnumerable<SendKosParameter> items)
        {
            foreach (var item in items)
            {
                var res = this.TeletipKosService.SendKos(item);
                Logger.LogInfo($"{res.IsSuccess}\t{res.Message}\t{item.KosFilePath}");
            }
        }
        public void MakeKos(IEnumerable<MakeKosParameter> items)
        {
            foreach (var item in items)
            {
                var res = this.TeletipKosService.MakeKos(item);
                Logger.LogInfo($"{res.IsSuccess}\t{res.Message}\t{item.AccessionNumber}\t{res.Arguments}");
            }
        }
    }
}
