//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TTCD1_TAQ_2210900058_PJ2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MayTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MayTinh()
        {
            this.ChiTietPhienChois = new HashSet<ChiTietPhienChoi>();
            this.PhienChois = new HashSet<PhienChoi>();
        }
    
        public int ma_may_tinh { get; set; }
        public string ten_may_tinh { get; set; }
        public string trang_thai { get; set; }
        public string vi_tri { get; set; }
        public Nullable<System.DateTime> ngay_tao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhienChoi> ChiTietPhienChois { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhienChoi> PhienChois { get; set; }
    }
}
