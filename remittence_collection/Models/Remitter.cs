using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace remittence_collection.Models
{
    public class Remitter
    {
        [Key]
        public string RemitterId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        [ForeignKey("PrimaryID")]
        public string PrimaryIDid { get; set; }
        public ID PrimaryID { get; set; }
        [ForeignKey("SecondaryID")]
        public string SecondaryIDid { get; set; }
        public ID SecondaryID { get; set; }
        public string PresentAddress { get; set; }
        public string NatureOfJob { get; set; }
        public int NationalityId { get; set; }
        public Country Nationality { get; set; }
        public string DateofBirth { get; set; }
        public double IncomeRange { get; set; }
        public double YearlyExpVolOfRemittence { get; set; }
        public int RemitterTypeId { get; set; }
        public RemitterType RemitterType { get; set; }
        public string Remarks { get; set; }
        public DateTime ActionDate { get; set; }
    }
}