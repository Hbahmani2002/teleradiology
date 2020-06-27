using System.Text;

namespace KOS.TeletipKos
{
    public class SendKosDataResult
    {
        public enum SendKosResultType
        {
            Failure = 0,
            Success = 1,
            PartialSuccess = 2,
        }
        public SendKosResultType? Type { get; set; }
        public string CodeContext { get; set; }
        public override string ToString()
        {

            var _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }

    }
}