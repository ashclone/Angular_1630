using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal_API.Model
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int  CountryId { get; set; }
        public Country Country { get; set; }
        
    }
}
