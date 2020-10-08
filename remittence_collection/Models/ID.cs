using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace remittence_collection.Models
{
    public class ID
    {
        [Key]
        public string IDNo { get; set; }
        [ForeignKey("IDType")]
        public int IDTypeId { get; set; }
        public IDType IDType { get; set; }
        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
    }
}