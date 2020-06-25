using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Core.Settings;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace GT.Repository.Conditions
{
    public class InfStudyConditionFilter
    {
        public enum KosEnumType
        {
            KosOlusturulamamisOlanlar = 10,
            KosOlusumuHataliOlanlar=20,
            KosOlusmusOlanlar = 30,
            KosHataliGonderileneler=40,
            KosGonderilipEslesmeyenler=50,
            KosGonderilipEslesenler = 60,
            KosSilinenler=70
        }
        public string Modality { get; set; }
        public long? Pk { get; set; }
        public long[] HastaneIDList { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }
        public string EslesmeDurumu { get; set; }
        public string[] AccessionNumberList { get; set; }
        public string[] TcList { get; set; }
        public KosEnumType? KosEnum { get; set; }
        public bool KosWaitHour { get; set; }
    }
    public class InfStudyCondition
    {
        public static Expression<Func<KosStudy , bool>> Get(InfStudyConditionFilter filter)
        {
            var exp = PredicateBuilder.True<KosStudy>();
            if (!string.IsNullOrEmpty(filter.Modality))
            {
                exp = exp.And(o => o.Modality.Contains(filter.Modality));
            }     
            if (filter.HastaneIDList!=null && filter.HastaneIDList.Length > 0)
            {
                var arr = filter.HastaneIDList.ToList();
                exp = exp.And(o => arr.Contains(o.FkTenant));
            }
            if (filter.KosWaitHour==true)
            {
                var hour = AppSettings.GetCurrent().DataServiceSettings.KosWaitHour;
                exp = exp.And(o => o.TimeCreated >= o.TimeCreated.Value.AddHours(-hour));
            }
            if (filter.TcList != null && filter.TcList.Length > 0)
            {
                var arr = filter.TcList.ToList();
                exp = exp.And(o => arr.Contains(o.PatientId));
            }
            if (filter.AccessionNumberList != null && filter.AccessionNumberList.Length > 0)
            {
                var arr = filter.AccessionNumberList.ToList();
                exp = exp.And(o => arr.Contains(o.AccessionNo));
            }
            if (filter.KosEnum.HasValue)
            {
                exp = exp.And(o => o.FkKosEnumType <= (int)filter.KosEnum.Value);
            }
            if (filter.BasTarih.HasValue)
            {
                exp = exp.And(o => o.TimeCreated <= filter.BasTarih.Value);
            }
            if (filter.BitTarih.HasValue)
            {
                exp = exp.And(o => o.TimeCreated >= filter.BitTarih.Value);
            }
            if (filter.Pk.HasValue)
            {
                exp = exp.And(o => o.Pk == filter.Pk.Value);
            }
            return exp;
        }
    }
}
