namespace MEDLIFE.SERVICE
{
    public class UserContextModel
    {
        public UserContextModel(int? userIDCurrent, int? firmaIDCurrent)
        {
            UserIDCurrent = userIDCurrent;
            FirmaIDCurrent = firmaIDCurrent;
        }

        public int? UserIDCurrent { get; set; }
        public int? FirmaIDCurrent { get; set; }

        public bool isFirma
        {
            get
            {
                return this.FirmaIDCurrent.HasValue;
            }
        }
    }
}