//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STOK.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MUSTERILER()
        {
            this.TBL_SATIS = new HashSet<TBL_SATIS>();
        }
    
        public int MUSTERIID { get; set; }
        public string MUSTERIAD { get; set; }
        public string MUSTERISOYAD { get; set; }
        public string MUSTERISEHIR { get; set; }
        public Nullable<decimal> MUSTERIBAKIYE { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SATIS> TBL_SATIS { get; set; }
    }
}
