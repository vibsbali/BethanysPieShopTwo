using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BethanysPieShop.Models
{
    public class Feedback
    {
        [BindNever]
        public int FeedbackId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Message { get; set; }

        [Display(Name = "Contact me")]
        public bool ContactMe { get; set; }
    }
}
