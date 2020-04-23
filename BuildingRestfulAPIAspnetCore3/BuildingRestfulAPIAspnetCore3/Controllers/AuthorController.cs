using AutoMapper;
using BuildingRestfulAPIAspnetCore3.Helpers;
using BuildingRestfulAPIAspnetCore3.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingRestfulAPIAspnetCore3.Controllers
{
    [ApiController]
    //[Route("api/authors")]
    [Route("api/[controller]")]
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
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
           
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }
        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            if (authorFromRepo == null) NotFound();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorFromRepo));
        }


    }
}
