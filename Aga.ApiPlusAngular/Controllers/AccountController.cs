using Aga.ApiPlusAngular.Helper;
using Aga.DataAccess;
using Aga.DataAccess.Entity;
using Aga.Domain.Implements;
using Aga.Domain.Interfaces;
using Aga.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _JWTTokenService;

        public AccountController(EFContext context, UserManager<User> user, SignInManager<User> sign, IJWTTokenService services)
        {
            _context = context;
            _userManager = user;
            _signInManager = sign;
            _JWTTokenService = services;
        }

        [HttpPost("register")]
        public async Task<ResultDTO> Register([FromBody] UserRegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Code = 405,
                        Message = "Error",
                        Errors = new List<string>() {
                        "Enter all fields"
                        }
                    };
                }
                else
                {
                    var user = new User
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.Phone,
                        Adress = model.Adress,
                        Age = model.Age,
                        Fullname = model.Fullname
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(user, "User").Result;
                        _context.SaveChanges();

                        return new ResultDTO
                        {
                            Code = 200,
                            Message = "Okk"
                        };
                    }
                    else
                    {
                        return new ResultErrorDTO
                        {
                            Code = 405,
                            Message = "Error",
                            Errors = CustomValidator.GetErrorsByIdentityResult(result)

                        };
                    };
                }

            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "Error",
                    Errors = new List<string> {
                e.Message
                        }
                };
            }
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


        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody] UserLoginDTO model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Code = 405,
                        Message = "Error",
                        Errors = new List<string>() {
                        "Enter all fields"
                        }
                    };
                }
                else
                {
                    var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false).Result;
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        await _signInManager.SignInAsync(user, false);

                        return new ResultLoginDTO
                        {
                            Code = 200,
                            Message = "Okk",
                            Token = _JWTTokenService.CreateToken(user)
                        };
                    }
                    else
                    {
                        return new ResultErrorDTO
                        {
                            Code = 405,
                            Message = "Error",
                            Errors = CustomValidator.GetErrorsByModelState(ModelState)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "Error",
                    Errors = new List<string> {
                e.Message
                        }
                };
            }
        }
    }
}
