using Aga.DataAccess;
using Aga.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Aga.DTO.Results.CollectionresultDTO;
using Aga.DTO.Add_ting_DTOs;
using Aga.ApiPlusAngular.Helper;
using Aga.DataAccess.Entity;

namespace Aga.ApiPlusAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly EFContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public AdminController(EFContext context)
        {
            _context = context;
        }

        [HttpGet("course")]
        public CollectionResultDto<CoursesDTO> GetCourses()
        {
            var coureses = _context.Courses.Select(c => new CoursesDTO
            {
                idTeacher = c.idTeacher,
                Description = c.Description,
                Image = c.Image,
                Name = c.Name,
                Price = c.Price,
                Smth = c.Smth,
                Id = c.Id
            }).ToList();
            return new CollectionResultDto<CoursesDTO>
            {
                Code = 200,
                Data = coureses,
                Message = "Okk!"
            };
        }
        [HttpGet("deleteCourses/{id}")]
        public ResultDTO DeleteCourse([FromRoute]int id)
        {
            try
            {
                if (id != null)
                {
                    var c = _context.Courses.FirstOrDefault(t=> t.Id == id);
                    _context.Courses.Remove(c);
                    _context.SaveChanges();
                    return new ResultDTO
                    {
                        Code = 200,
                        Message = "Successfully deleted"
                    };
                }
                else
                {
                    return new ResultDTO
                    {
                        Code = 400,
                        Message = "Id is not defined"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Code = 400,
                    Message = e.Message
                };
            }
        }
        [HttpGet("groups")]

        public CollectionResultDto<GroupsDTO> GetGroups()
        {
            var coureses = _context.Groups.Select(c => new GroupsDTO
            {
                idTeacher = c.idTeacher,
                Image = c.Image,
                Name = c.Name,
                Id = c.Id

            }).ToList();
            return new CollectionResultDto<GroupsDTO>
            {
                Code = 200,
                Data = coureses,
                Message = "Okk!"
            };
        }
        [HttpGet("deleteGroups/{id}")]
        public ResultDTO DeleteGroup([FromRoute] int? id)
        {
            try
            {
                if (id != null)
                {
                    var c = _context.Groups.FirstOrDefault(t=> t.Id == id);
                    _context.Remove(c);
                    _context.SaveChanges();
                    return new ResultDTO
                    {
                        Code = 200,
                        Message = "Successfully deleted"
                    };
                }
                else
                {
                    return new ResultDTO
                    {
                        Code = 400,
                        Message = "Id is not defined"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Code = 400,
                    Message = e.Message
                };
            }
        }
        [HttpGet("news")]

        public CollectionResultDto<NewsDTO> GetNews()
        {
            var news = _context.News.Select(c => new NewsDTO
            {
                Image = c.Image,
                Title = c.Title,
                Id = c.Id
            }).ToList();
            return new CollectionResultDto<NewsDTO>
            {
                Code = 200,
                Data = news,
                Message = "Okk!"
            };
        }
        [HttpGet("deleteNews/{id}")]
        public ResultDTO DeleteNew([FromRoute] int? id)
        {
            try
            {
                if (id != null)
                {
                    var c = _context.News.FirstOrDefault(t=> t.Id == id);
                    _context.Remove(c);
                    _context.SaveChanges();
                    return new ResultDTO
                    {
                        Code = 200,
                        Message = "Successfully deleted"
                    };
                }
                else
                {
                    return new ResultDTO
                    {
                        Code = 400,
                        Message = "Id is not defined"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Code = 400,
                    Message = e.Message
                };
            }
        }

        [HttpPost("addNews")]
        [Authorize(Roles = "Admin")]
        public ResultDTO addNews([FromBody] AddNewsDTO model) {
            if (!ModelState.IsValid) {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.GetErrorsByModelState(ModelState)
                };
            }

            New @new = new New
            {
                Title = model.Title,
                Image = model.Image,
            };
            _context.News.Add(@new);
            _context.SaveChanges();

            return new ResultErrorDTO
            {
                Code = 200,
                Message = "Okk"
            };
        }

        [HttpPost("addCourses")]
        [Authorize(Roles = "Admin")]
        public ResultDTO addCourses([FromBody] AddCoursesDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.GetErrorsByModelState(ModelState)
                };
            }

            Course course    = new Course
            {
                Image = model.Image,
                Description = model.Description,
                idTeacher = model.idTeacher,
                Name = model.Name,
                Price = model.Price,
                Smth = model.Smth
            };
            _context.Courses.Add(course);
            _context.SaveChanges();

            return new ResultErrorDTO
            {
                Code = 200,
                Message = "Okk"
            };
        }

        [HttpPost("addGroups")]
        [Authorize(Roles = "Admin")]
        public ResultDTO addGroups([FromBody] AddGroupsDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.GetErrorsByModelState(ModelState)
                };
            }

            Group group = new Group
            {
                Image = model.Image,
                idTeacher = model.idTeacher,
                Name = model.Name,
            };
            _context.Groups.Add(group);
            _context.SaveChanges();

            return new ResultErrorDTO
            {
                Code = 200,
                Message = "Okk"
            };
        }

        [HttpPost("addStudents")]
        [Authorize(Roles = "Admin")]
        public ResultDTO addStudents([FromBody] AddStudentsDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.GetErrorsByModelState(ModelState)
                };
            }

            Student student = new Student
            {
                Image = model.Image,
                Name = model.Name,
                Age = model.Age,
                IdGroup = model.IdGroup,
                IsPay = model.IsPay
            };
            _context.Students.Add(student);
            _context.SaveChanges();

            return new ResultErrorDTO
            {
                Code = 200,
                Message = "Okk"
            };
        }

        [HttpPost("addTeachers")]
        [Authorize(Roles = "Admin")]
        public ResultDTO addTeachers([FromBody] AddTeachersDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.GetErrorsByModelState(ModelState)
                };
            }

            Teacher teacher = new Teacher
            {
                Image = model.Image,
                Name = model.Name,
                Age = model.Age,
                Description = model.Description,
                Rates = model.Rates
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return new ResultErrorDTO
            {
                Code = 200,
                Message = "Okk"
            };
        }



        [HttpGet("students")]

        public CollectionResultDto<StudentDTO> GetStudents()
        {
            var students = _context.Students.Select(c => new StudentDTO
            {
                Image = c.Image,
                Name = c.Name,
                Age = c.Age,
                IdGroup = c.IdGroup,
                IsPay = c.IsPay,
                Id = c.Id
            }).ToList();
            return new CollectionResultDto<StudentDTO>
            {
                Code = 200,
                Data = students,
                Message = "Okk!"
            };
        }
        [HttpGet("deleteStudents/{id}")]
        public ResultDTO DeleteStudent([FromRoute] int? id)
        {
            try
            {
                if (id != null)
                {
                    var c = _context.Students.Find(id);
                    _context.Remove(c);
                    _context.SaveChanges();
                    return new ResultDTO
                    {
                        Code = 200,
                        Message = "Successfully deleted"
                    };
                }
                else
                {
                    return new ResultDTO
                    {
                        Code = 400,
                        Message = "Id is not defined"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Code = 400,
                    Message = e.Message
                };
            }
        }
        [HttpGet("teachers")]
        public CollectionResultDto<TeacherDTO> GetTeachers()
        {
            var coureses = _context.Teachers.Select(c => new TeacherDTO
            {
                Description = c.Description,
                Image = c.Image,
                Name = c.Name,
                Age = c.Age,
                Rates = c.Rates,
                Id = c.Id
            }).ToList();
            return new CollectionResultDto<TeacherDTO>
            {
                Code = 200,
                Data = coureses,
                Message = "Okk!"
            };
        }
        [HttpGet("deleteTeachers/{id}")]
        public ResultDTO DeleteTeacher([FromRoute] int? id)
        {
            try
            {
                if (id != null)
                {
                    var c = _context.Teachers.FirstOrDefault(t=> t.Id == id);
                    _context.Remove(c);
                    _context.SaveChanges();
                    return new ResultDTO
                    {
                        Code = 200,
                        Message = "Successfully deleted"
                    };
                }
                else
                {
                    return new ResultDTO
                    {
                        Code = 400,
                        Message = "Id is not defined"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Code = 400,
                    Message = e.Message
                };
            }
        }


    }
}
