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

    public partial class tblPoljoprivrednoGazdinstvo
    {
        public int PoljoprivrednoGazdinstvoID { get; set; }
        public Nullable<int> Vlasnik { get; set; }
        public string Povrsina { get; set; }
        public Nullable<int> Registracija { get; set; }
        public Nullable<int> Osiguranje { get; set; }
        public Nullable<int> Dokumentacija { get; set; }
    
        public virtual tblDokumetacija tblDokumetacija { get; set; }
        public virtual tblOsiguranje tblOsiguranje { get; set; }
        public virtual tblRegistracija tblRegistracija { get; set; }
        public virtual tblVlasnik tblVlasnik { get; set; }
    }
}
