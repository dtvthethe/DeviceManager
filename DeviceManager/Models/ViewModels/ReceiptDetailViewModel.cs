using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class ReceiptDetailViewModel
    {
        public int ID { get; set; }


        public int IDReceipt { get; set; }

        [Display(Name = "Tên thiết bị")]
        public int IDDevice { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public string UpdatedBy { get; set; }

        public virtual DeviceViewModel Device { get; set; }

        public virtual Receipt Receipt { get; set; }

    }
}