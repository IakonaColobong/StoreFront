using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;//added in attempt to link scaffold DB


namespace StoreFront.DATA.EF//.StoreFrontMetadata
{
    public class AuthorTableMetadata
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "*")]
        [StringLength(15, ErrorMessage = "* Value must be 15 characters or less")]// makes client side check vchar length to make sure it works for DB 
        //instead of sub mitting and waiting for the sevrer to decline. 
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "*")]
        [StringLength(15, ErrorMessage = "* Value must be 15 characters or less")]
        public string LName { get; set; }
    }
    [MetadataType(typeof(AuthorTableMetadata))]

    public partial class AuthorTable
    {
        //custom properties - defined in the BUDDY (partial) class with the same name as the Model
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return $"{FName} {LName}"; }
        }
    }
}
