using Util.File;

namespace IzcilikSistemi.BAL.Web.Ajax
{

    public class FileResultData
    {
        private string _FullPath;
        public string RelativePath => FileOps.GetRelativeFileName(_FullPath);
        //public long Id { get; set; }
        public FileResultData(string fullPath)
        {
            _FullPath = fullPath;
        }

        public string GetFullPath()
        {
            return _FullPath;
        }
    }

}