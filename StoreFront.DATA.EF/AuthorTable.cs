//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreFront.DATA.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthorTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AuthorTable()
        {
            this.BooksTables = new HashSet<BooksTable>();
        }
    
        public int AuthorID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
