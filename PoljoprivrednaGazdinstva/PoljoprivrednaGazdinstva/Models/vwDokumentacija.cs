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
    
    public partial class vwDokumentacija
    {
        public int DokumetID { get; set; }
        public string Vrsta { get; set; }
        public Nullable<System.DateTime> DatumIzdavanja { get; set; }
        public Nullable<System.DateTime> DatumIsteka { get; set; }
        public string Mesto { get; set; }
        public int Ekspozitura { get; set; }
        public string Adresa { get; set; }
    }
}