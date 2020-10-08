using System;
using System.ComponentModel.DataAnnotations;

namespace remittence_collection.Models
{
    public class Beneficiary
    {
        public string RemitterId { get; set; }
        public Remitter Remitter { get; set; }
        [Key]
        public string BeneficiaryId { get; set; }
        public int NationalityId { get; set; }
        public Country Nationality { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public string MobileNo { get; set; }
        public string RelationWithRemitter { get; set; }
        public string Remarks { get; set; }
        public DateTime ActionDate { get; set; }
    }
}