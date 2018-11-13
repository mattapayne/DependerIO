using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DependerIO.Api.Models;
using DependerIO.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DependerIO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _repository;

        public ServicesController(IMapper mapper, IServiceRepository repository) {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAsync() {
            var models = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<DTO.Service>>(models);
            return Ok(dtos);
        }
    }
}
