using AutoMapper;
using BuildingRestfulAPIAspnetCore3.Helpers;
using BuildingRestfulAPIAspnetCore3.Models;
using BuildingRestfulAPIAspnetCore3.ResourceParameters;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingRestfulAPIAspnetCore3.Controllers
{
    [ApiController]
    [Route("api/authors")]
    //[Route("api/[controller]")]
    public class AuthorController: ControllerBase
    {   
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorController(ICourseLibraryRepository courseLibraryRepository,IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? 
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery]AuthorsResourceParameters authorsResourceparameters)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceparameters);
           
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }
        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            if (authorFromRepo == null) return NotFound();
            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }


    }
}
