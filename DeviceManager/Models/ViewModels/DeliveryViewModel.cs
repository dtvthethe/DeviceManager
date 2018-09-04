using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManager.Models.ViewModels
{
    public class DeliveryViewModel
    {

        public int ID { get; set; }

        [Display(Name ="Đại diện kho: Ông (Bà)")]
        public string UsernameFromDelivery { get; set; }

        [Display(Name = "Đại diện bên nhận: Ông (Bà)")]
        public string UsernameToDelivery { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public string UpdatedBy { get; set; }

        public SelectList UserList { get; set; }

        // Get Header Only
        public readonly DeliveryDetailViewModel DeliveryDetail;

        public virtual ICollection<DeliveryDetailViewModel> DeliveryDetails { get; set; }

        public ICollection<DeliveryDetailEditViewModel> DeliveryDetailEdits { get; set; }

        public User User { get; set; }
        public User User1 { get; set; }

    }
}