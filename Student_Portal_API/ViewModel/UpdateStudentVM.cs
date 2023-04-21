using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal_API.ViewModel
{
    public class UpdateStudentVM
    {
        
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string ProfileImage { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
    }
}
