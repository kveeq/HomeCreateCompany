//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ychebka3KYRSKrasnov.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Railing_For_Home
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Railing_For_Home()
        {
            this.Home_Railing = new HashSet<Home_Railing>();
        }
    
        public int ID_Railing { get; set; }
        public string Color_Railing { get; set; }
        public byte[] Image_Railing { get; set; }
        public Nullable<decimal> Price_Railing { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Home_Railing> Home_Railing { get; set; }
    }
}
