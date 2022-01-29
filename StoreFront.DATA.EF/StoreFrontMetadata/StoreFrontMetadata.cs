using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF//.StoreFrontMetadata
{
    public class AuthorTableMetadata
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage ="20 character max")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "20 character max")]
        public string LName { get; set; }
    }

    [MetadataType(typeof(AuthorTableMetadata))]
    public partial class AuthorTable
    {
        public string FullName
        {
            get { return FName + " " + LName; }
        }
    }

    public class BooksTableMetadata
    {
        [Required]
        [Display(Name = "Book Title")]
        [StringLength(40, ErrorMessage ="40 character max")]
        public string BooksTitle { get; set; }
    }
}
