using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class DeliveryDetailEditViewModel
    {

        public DeviceEditViewModel Device { get; set; }

        public int ID { get; set; }

        [Display(Name ="Tên thiết bị")]
        public int IDDevice { get; set; }

        public int IDDelivery { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        public int Index { get; set; }

        [Display(Name = "Thời gian khấu hao")]
        public string DateExpires { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public ActionEnum Action { get; set; }

        public Page Page { get; set; }

    }
}