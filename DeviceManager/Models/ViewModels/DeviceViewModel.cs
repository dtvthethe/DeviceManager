using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class DeviceViewModel
    {
        public int ID { get; set; }

        [Display(Name ="Tên thiết bị")]
        public string Name { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        public int IDCategory { get; set; }

        public int IDUnit { get; set; }

        public int IDStatus { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Thông tin")]
        public string Info { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public string UpdatedBy { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }

        public virtual Status Status { get; set; }

        [Display(Name = "Đơn vị tính")]
        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}