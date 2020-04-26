using BuildingRestfulAPIAspnetCore3.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingRestfulAPIAspnetCore3.Models
{
    [CourseTitleMustBeDifferentFromDescriptionAttribute
        (ErrorMessage = "Title  must be different from description")]
    public abstract class CourseForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a title")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        public string Title { get; set; }
        [MaxLength(1500, ErrorMessage = "The Desciption shouldn't have more than 1000 characters.")]
        public virtual string Description { get; set; }
    }
}
