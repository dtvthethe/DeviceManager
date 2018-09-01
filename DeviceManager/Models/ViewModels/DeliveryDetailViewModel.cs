using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManager.Models.ViewModels
{
    public class DeliveryDetailViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Tên thiết bị")]
        public int IDDevice { get; set; }

        public int IDDelivery { get; set; }

        [Display(Name = "Số lượng")]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Thời gian khấu hao")]
        public System.DateTime DateExpires { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public string UpdatedBy { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual DeviceViewModel Device { get; set; }


        public SelectList DeviceList { get; set; }

        public Page Page { get; set; }


    }
}