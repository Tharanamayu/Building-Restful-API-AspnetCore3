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

        public AuthorController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? 
                throw new ArgumentNullException(nameof(courseLibraryRepository));
        }
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            return Ok(authorsFromRepo);
        }
        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            if (authorFromRepo == null) NotFound();
            return Ok(authorFromRepo);
        }


    }
}
