using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManager.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Người nhận")]
        public string UsernameReceipt { get; set; }

        [Display(Name = "Họ và tên người giao")]
        public int IDProvider { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public string UpdatedBy { get; set; }

        public Provider Provider { get; set; }

        public User User { get; set; }

        public SelectList UserList { get; set; }

        public SelectList ProviderList { get; set; }

        //Get header only:
        public DeviceViewModel Device;

        public ICollection<DeviceViewModel> Devices { get; set; }

        public ICollection<DeviceEditViewModel> DeviceEdits { get; set; }

    }
}