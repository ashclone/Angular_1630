using Student_Portal_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal_API.service.Infrastructure
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetGenderAsync();
    }
}
