namespace GT.Core.Settings
{
    public partial class AppSettings
    {
        public class DatabaseSettings
        {
            public DatabaseSettings(string studyPostgre, string infinityOracle, string pacsPostgre)
            {
                StudyPostgre = studyPostgre;
                InfinityOracle = infinityOracle;
                PacsPostgre = pacsPostgre;
            }

            public string StudyPostgre { get; set; }
            public string InfinityOracle { get; set; }
            public string PacsPostgre { get; set; }
        }
    }
}
