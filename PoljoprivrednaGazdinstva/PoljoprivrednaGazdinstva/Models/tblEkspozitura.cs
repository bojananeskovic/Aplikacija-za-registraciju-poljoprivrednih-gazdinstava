//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PoljoprivrednaGazdinstva.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblEkspozitura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEkspozitura()
        {
            this.tblDokumetacijas = new HashSet<tblDokumetacija>();
        }
    
        public int EkspozituraID { get; set; }
        public int Institucija { get; set; }
        [Display(Name = "Adresa ekspoziture")]
        public string Adresa { get; set; }
        public Nullable<int> Telefon { get; set; }
        public string Grad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDokumetacija> tblDokumetacijas { get; set; }
        public virtual tblInstitucija tblInstitucija { get; set; }
    }
}
