//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
        public string Username { get; set; }
        [Required(ErrorMessage = "Image Name is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
    
        public virtual Category Category1 { get; set; }
        public virtual User User { get; set; }
    }
}
