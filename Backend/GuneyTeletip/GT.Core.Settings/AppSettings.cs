﻿using GT.Core.Settings.Global;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GT.Core.Settings
{
    public partial class AppSettings
    {
        private const string SettingsFilePath = "appsettings.json";

        private static AppSettings _AppSettings;
        public static AppSettings GetCurrent()
        {
            if (_AppSettings == null)
            {
                lock (SettingsFilePath)
                {
                    if (_AppSettings == null)
                    {
                        try
                        {
                            var file = File.ReadAllText(SettingsFilePath, Encoding.UTF8);
                            var model = new
                            {
                                ConnectionStrings = new
                                {
                                    StudyPostgre = "",
                                    InfinityOracle = "",
                                    PacsPostgre=""
                                }
                            };
                            model = JsonConvert.DeserializeAnonymousType(file, model);
                            if (model == null || model.ConnectionStrings == null)
                            {
                                throw new Exception("model boş");
                            }
                            _AppSettings = new AppSettings(new DatabaseSettings(model.ConnectionStrings.StudyPostgre, model.ConnectionStrings.InfinityOracle, model.ConnectionStrings.PacsPostgre));
                            //LoadSettings_Alpha()
                            //LoadSettings_Beta()
                        }
                        catch (Exception ex)
                        {
                            _AppSettings = new AppSettings();
                            _AppSettings.ConfigFileException = ex.ToString();
                            var msg = $"{SettingsFilePath} dosaysından global ayarlar çekilmedi";
                            Debug.WriteLine(msg);

                            Debug.WriteLine(ex);

                        }
                    }
                }
            }
            return _AppSettings;


        }
        public DatabaseSettings DatabaseSetting { get; }
        public bool IsFromConfigFile { get; set; }
        private AppSettings()
        {
            //vvvvvv
            DatabaseSetting = new DatabaseSettings(
               "Host=85.95.238.211;Database=guney_teletip_db;Username=postgres;Password=protek..psql..2020;Port=9002",
               "User Id=test_user;Password=protek_oracle_2020;Data Source=85.95.238.211:9003/xe;",
               "Host=85.95.239.134;Database=pacsdb;Username=pacs;Password=pacs;Port=5432"
               );
        }
        public string ConfigFileException { get; set; }
        private AppSettings(DatabaseSettings set)
        {
            IsFromConfigFile = true;
            DatabaseSetting = set;
        }

        public GlobalAppSettings.DataServiceSettings DataServiceSettings => GlobalAppSettings.GetCurrent().DataService;

        public GlobalAppSettings.STMServiceSetting STM => GlobalAppSettings.GetCurrent().STMSettings;

        public GlobalAppSettings.LoggingSetting Log => GlobalAppSettings.GetCurrent().LogSettings;
        public GlobalAppSettings.KosServiceSetting Kos => GlobalAppSettings.GetCurrent().KosServiceSettings;

    }
}
