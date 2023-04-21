using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Portal_API.Model
{
    public class Address
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }       
        //[NotMapped]
        //[Display(Name = "State")]
        //public int StateId { get; set; }
        //[NotMapped]
        //[Display(Name = "Country")]
        //public int CountryId { get; set; }
        
    }
}