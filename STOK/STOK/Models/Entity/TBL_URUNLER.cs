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
    
    public partial class TBL_URUNLER
    {
        public int URUNID { get; set; }
        public string URUNAD { get; set; }
        public string URUNMARKA { get; set; }
        public Nullable<short> URUNSTOK { get; set; }
        public Nullable<decimal> URUNALISFIYAT { get; set; }
        public Nullable<decimal> URUNSATISFIYAT { get; set; }
        public Nullable<int> KATEGORI { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual TBL_KATEGORILER TBL_KATEGORILER { get; set; }
        public virtual TBL_SATIS TBL_SATIS { get; set; }
    }
}
