using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DependerIO.Api.Models;
using DependerIO.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace DependerIO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandlersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHandlerRepository _repository;

        public HandlersController(IMapper mapper, IHandlerRepository repository) {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetAsync(Guid id) {
            var models = await _repository.GetAllAsync(id);
            var dtos = _mapper.Map<IEnumerable<DTO.Handler>>(models);
            return Ok(dtos);
        }
    }
}
