using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnterpriseApp.Models
{
    public class ArticleUploadModel
    {
        [Required(ErrorMessage = "Heading is required")]
        [StringLength(50, ErrorMessage = "Heading cannot be longer than 50 characters.")]
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int Category { get; set; }
        public bool IsBreaking { get; set; }
    }
}