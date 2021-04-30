using Aga.ApiPlusAngular.Helper;
using Aga.DataAccess;
using Aga.DataAccess.Entity;
using Aga.DTO;
using Aga.DTO.Add_ting_DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Aga.DTO.Results.CollectionresultDTO;

namespace Aga.ApiPlusAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly EFContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public TeacherController(EFContext context)
        {
            _context = context;
        }

        [HttpGet("homework")]
        public CollectionResultDto<HomeworkDTO> GetHomework()
        {
            var homeworks = _context.Homeworks.Select(c => new HomeworkDTO
            {
                idTeacher = c.idTeacher,
                Description = c.Description,
                Image = c.Image,
                Name = c.Name,                  
                Id = c.Id
            }).ToList();
            return new CollectionResultDto<HomeworkDTO>
            {
                Code = 200,
                Data = homeworks,
                Message = "Okk!"
            };
        }

        [HttpGet("deleteHomework/{id}")]
        public ResultDTO DeleteHomework([FromRoute] int id)
        {
            try
            {
                if (id != null)
                {
                    var c = _context.Homeworks.FirstOrDefault(t => t.Id == id);
                    _context.Homeworks.Remove(c);
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

        [HttpGet("myGroup/{id}")]
        public CollectionResultDto<GroupsDTO> GetGroups([FromRoute]string id)
        {
            var groups = _context.Groups.Select(c => new GroupsDTO
            {
                Image = c.Image,
                Name = c.Name,
                Id = c.Id,
            }).Where(c => c.idTeacher == id).ToList();
            return new CollectionResultDto<GroupsDTO>
            {
                Code = 200,
                Data = groups,
                Message = "Okk!"
            };
        }

        [HttpPost("addHomework")]
        [Authorize(Roles = "Teacher")]
        public ResultDTO addHomewrok([FromBody] AddHomeworkDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.GetErrorsByModelState(ModelState)
                };
            }

            Homework homework = new Homework
            {
                Image = model.Image,
                Description = model.Description,
                idTeacher = model.idTeacher,
                Name = model.Name
            };
            _context.Homeworks.Add(homework);
            _context.SaveChanges();

            return new ResultErrorDTO
            {
                Code = 200,
                Message = "Okk"
            };
        }

    }
}
