namespace MEDLIFE.PERSISTANCE.DOMAIN.Models
{
    using GT.Persistance.Domain.infinity.Models;
    using GT.Persistance.infinity.Util;
    using MEDLIFE.PERSISTANCE.Data.SQL;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : CommonDbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
        public DataContext(bool autoDetectChangesEnabled, bool proxyCreationEnabled = true, bool lazyLoadingEnabled = true, bool validateOnSaveEnabled = true, Action<string> logAction = null)
           : base($"name={LocalSettings.AppName}")
        {
            //Database.SetInitializer<DataContext>(null);
            //Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            //Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            //Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            //Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
            //if (logAction != null)
            //{
            //    Database.Log = logAction;
            //}
        }
 
    }
}
