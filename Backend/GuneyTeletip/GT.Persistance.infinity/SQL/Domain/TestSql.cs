using System.ComponentModel.DataAnnotations;

namespace GT.PERSISTANCE.DOMAIN.Models
{
    public class TestSql
    {
        [Key]
        public decimal STUDY_KEY { get; set; }

        public string PATIENT_ID { get; set; }
    }
}
