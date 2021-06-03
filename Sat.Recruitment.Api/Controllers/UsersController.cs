using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.Util;
using Sat.Recruitment.Model.DTO;
using Sat.Recruitment.Services;

using AutoMapper;

namespace Sat.Recruitment.Api.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserServices _services;
        private readonly IMapper _mapper;

        public UsersController(IUserServices services, IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {

            try
            {
                var newUser = _services.CreateUser(userDTO);
                return Created("j", (_mapper.Map<UserDTO>(newUser)));

            }
            catch (DuplicatedUserException e)
            {
                var result = new ObjectResult(e.ToString());
                result.StatusCode = 412;
                return result;
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e.ToString());
                result.StatusCode = 500;
                return result;
            }

        }


        [HttpGet]
        [Route("/user/{email}")]
        public ActionResult<UserDTO>  GetUser(String email)
        {
            try
            {
                return Ok(_mapper.Map<UserDTO>(_services.getUser(email)));
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e.ToString());
                result.StatusCode = 500;
                return result;
            }
        }

    }

}
