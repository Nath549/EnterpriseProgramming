
namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Article
    {
        public int ArticleID { get; set; }
        [Required(ErrorMessage = "Heading is required")]
        [StringLength(50, ErrorMessage = "Heading cannot be longer than 50 characters.")]
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int Category { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public bool IsBreaking { get; set; }
    
        public virtual Category Category1 { get; set; }
        public virtual User User { get; set; }
    }
}
