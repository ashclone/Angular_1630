using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Student_Portal_API.data;
using Student_Portal_API.Model;
using Student_Portal_API.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Student_Portal_API.service
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
       
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(nameof(Gender)).Include(nameof(Address))
                .Include(x=>x.Address.City)
                .Include(x=>x.Address.City.State)
                .Include(x=>x.Address.City.State.Country)
                .ToListAsync();
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _context.Students.Where(x => x.Id == id)
                .Include(x=>x.Gender).Include(x=>x.Address)
                .Include(x => x.Address.City)
                .Include(x => x.Address.City.State)
                .Include(x => x.Address.City.State.Country)
                .FirstOrDefaultAsync();
           
        }
       public async Task<bool> Exists(int id)
        {
            return await _context.Students.AnyAsync(x=>x.Id==id);
        }

        public async Task<Student> UpdateStudentAsync(int id, UpdateStudentVM studentVm)
        {
            var stuInDb = await _context.Students.Include(nameof(Address)).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (stuInDb != null)
            {
                stuInDb.Name = studentVm.Name;
                stuInDb.Email = studentVm.Email;
                stuInDb.BirthDate = studentVm.BirthDate;
                stuInDb.Contact = studentVm.Contact;
                stuInDb.GenderId = studentVm.GenderId;
                stuInDb.Address.PhysicalAddress = studentVm.PhysicalAddress;
                stuInDb.Address.PostalCode = studentVm.PostalCode;
                stuInDb.Address.CityId = studentVm.CityId;
                await _context.SaveChangesAsync();
                return stuInDb;
                
            }
            return null;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var studentInDb = await GetStudentAsync(id);
            if (studentInDb != null)
            {                
                _context.Students.Remove(studentInDb);
                if (studentInDb.ProfileImage != null)
                {

                var oldImgPath = Path.Combine(Directory.GetCurrentDirectory(), studentInDb.ProfileImage.TrimStart('\\'));
                if (oldImgPath != null)
                {
                    if (File.Exists(oldImgPath))
                    {
                       File.Delete(oldImgPath);
                    }
                }
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
           
        }

        public async Task<Student> AddStudent(UpdateStudentVM VM)
        {
            if (VM != null)
            {
                Student student = new();
                student.Name = VM.Name;
                student.Email = VM.Email;
                student.Contact = VM.Contact;
                student.BirthDate = VM.BirthDate;
                student.GenderId = VM.GenderId;
                student.ProfileImage = VM.ProfileImage;
                student.Address = new Address()
                {
                    PhysicalAddress = VM.PhysicalAddress,
                    PostalCode = VM.PostalCode,
                    CityId = VM.CityId

                };
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<string> AddImage(IFormFile file)
        {
            var GuidId = Guid.NewGuid().ToString();
            var filename = GuidId + "_" + file.FileName;
            var fileUploadPath = Path.Combine(Directory.GetCurrentDirectory(), @"Images\StudentsProfile",filename);
            using(FileStream fileStream =new FileStream(fileUploadPath, FileMode.Create))
            {

               await file.CopyToAsync(fileStream);
            }
            
            return Path.Combine(@"Images\StudentsProfile", filename);

        }

        public async Task<bool> UpdateImage(int id, string ImageUrl)
        {
            var studentInDb = await GetStudentAsync(id);
            if (studentInDb != null)
            {
                if (studentInDb.ProfileImage == null)
                    studentInDb.ProfileImage = ImageUrl;
                else
                {
                    var oldImgPath = Path.Combine(Directory.GetCurrentDirectory(), studentInDb.ProfileImage.TrimStart('\\'));
                    if (oldImgPath != null)
                    {
                        if (File.Exists(oldImgPath))
                        {
                            File.Delete(oldImgPath);
                        }
                    }
                    studentInDb.ProfileImage = ImageUrl;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
