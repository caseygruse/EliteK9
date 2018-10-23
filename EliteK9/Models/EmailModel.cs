using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteK9.Models
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [Required]
        public string Message { get; set; }
    }
}