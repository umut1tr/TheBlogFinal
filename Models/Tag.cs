using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TheBlogFinal.Models
{
    public class Tag
    {

        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be atleast {2} and nor more than {1} characters long", MinimumLength = 2)]
        public string Text { get; set; }

        public virtual Post Post { get; set; } // Post is Parentclass from Tag
        public virtual BlogUser Author { get; set; } 

        p

    }
}
