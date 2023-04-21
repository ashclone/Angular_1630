using Microsoft.AspNetCore.Http;
using Student_Portal_API.Model;
using Student_Portal_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Student_Portal_API.service
{
   public interface IStudentRepository
    {
       Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentAsync( int id);
        Task<bool> DeleteStudentAsync( int id);
        Task<bool> Exists(int id);
        Task<Student> UpdateStudentAsync(int id, UpdateStudentVM studentVM);
        Task<Student> AddStudent(UpdateStudentVM studentVM);
        Task<string> AddImage(IFormFile file);
        Task<bool> UpdateImage(int id,string ImageUrl);



    }
}
