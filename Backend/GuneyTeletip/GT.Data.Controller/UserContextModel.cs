namespace MEDLIFE.SERVICE
{
    public class UserContextModel
    {
        public UserContextModel(int? userIDCurrent)
        {
            UserIDCurrent = userIDCurrent;
        }

        public int? UserIDCurrent { get; set; }
    }
}