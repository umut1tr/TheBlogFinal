using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TheBlogFinal.Enums;

namespace TheBlogFinal.Models
{
    public class Post
    {

        public int Id { get; set; } // primary key

        [Display(Name = "Blog Name")]
        public int BlogId { get; set; } // foreign key from Blog ID
        public string BlogUserId { get; set; } // foreign key for Author

        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)] // index 0 = Title , index 1 = MaxLength , index 2 = MinLength
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)] // index 0 = Abstract , index 1 = MaxLength , index 2 = MinLength
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)] // used for when using a Date or Time Picker later on
        [Display(Name = "Created Date")]        
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        
        public ReadyStatus ReadyStatus { get; set; } // enum seksy

        public string Slug { get; set; } // not entered by user it will be driven by title which user enters  // SEO etc. 


        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [NotMapped] // will exclude DB Mapping
        public IFormFile Image { get; set; } // will be used to assist to the physical img the user puts on later into ImageData

        //Navigation property
        public virtual Blog Blog { get; set; } // Blog is Parentclass of Post
        public virtual BlogUser BlogUser { get; set; } // role of admin? or author ? lets see

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>(); // HashSet implementing ICollection for Tags
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
