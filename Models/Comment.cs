using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheBlogFinal.Enums;

namespace TheBlogFinal.Models
{
    public class Comment
    {

        public int Id { get; set; } // primary key
        public int PostId { get; set; } // foreign key to Post
        public string AuthorId { get; set; } // foreign key
        public string ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more then {1} characters long.", MinimumLength = 2)] // Index 0 = Name , Index 1 = MaxLength , Index 2 = MinLength
        [Display(Name = "Comment")]
        public string Body { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more then {1} characters long.", MinimumLength = 2)] // Index 0 = Name , Index 1 = MaxLength , Index 2 = MinLength
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; }

        public ModerationType ModerationType { get; set; }


        // Navigation properties
        public virtual Post Post { get; set; } 
        public virtual BlogUser Author { get; set; } // anyone registered on the site which can then post comments on posts etc.
        public virtual BlogUser Moderator { get; set; } // special user of role mod

    }
}
