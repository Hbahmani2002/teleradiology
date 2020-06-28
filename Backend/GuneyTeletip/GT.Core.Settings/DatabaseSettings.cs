namespace GT.Core.Settings
{
    public partial class AppSettings
    {
        public class DatabaseSettings
        {
            public DatabaseSettings(string studyPostgre, string infinityOracle)
            {
                StudyPostgre = studyPostgre;
                InfinityOracle = infinityOracle;
            }

            public string StudyPostgre { get; set; }
            public string InfinityOracle { get; set; }
        }
    }
}
