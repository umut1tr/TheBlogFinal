using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogFinal.Models
{
    public class Blog
    {

        public int Id { get; set; } // primary key
        public string BlogUserId { get; set; } // foreign key


        [Required] // makes sure no Blog will be created without the Name property
        [StringLength(100, ErrorMessage = "{0} must be at least {2} and at most {1} characters.", MinimumLength = 2)] // Index 0 = Name , Index 1 = MaxLength , Index 2 = MinLength 
        public string Name { get; set; }

        [Required] // makes sure no Blog will be created without the Description property
        [StringLength(500, ErrorMessage = "{0} must be at least {2} and at most {1} characters.", MinimumLength = 2)] // Index 0 = Name , Index 1 = MaxLength , Index 2 = MinLength 
        public string Description { get; set; }

        [DataType(DataType.Date)] // helps display later if i need a datetime picker or some sort of to handle this shit as date type
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)] // helps display later if i need a datetime picker or some sort of to handle this shit as date type
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        [Display(Name = "Blog Image")] // display "Blog Image" instead of ImageData
        public byte[] ImageData { get; set; }

        [Display(Name = "Image Type")] // display "Image Type" instead of ImageData
        public string ContentType { get; set; }       
        
        [NotMapped] // will not map the property into the Database
        public IFormFile Image { get; set; }

        //Navigation property
        public virtual BlogUser BlogUser { get; set; } // parent class ,, USERNAME is UNIQUE and will be used to track
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>(); // HashSet implementing ICollection for Posts

    }
}
