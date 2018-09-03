//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeviceManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.DeliveryDetails = new HashSet<DeliveryDetail>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int IDCategory { get; set; }
        public int IDUnit { get; set; }
        public int IDStatus { get; set; }
        public int IDReceipt { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Note { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual Status Status { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
