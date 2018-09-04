using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class DeviceEditViewModel
    {

        public int ID { get; set; }

        [Display(Name = "Tên thiết bị")]
        public string Name { get; set; }

        public string UnitName { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        public int IDReceipt { get; set; }

        [Display(Name = "Danh mục")]
        public int IDCategory { get; set; }

        [Display(Name = "Đơn vị tính")]
        public int IDUnit { get; set; }

        [Display(Name = "Trạng thái")]
        public int IDStatus { get; set; }

        public ViewModelBase Category { get; set; }

        public ViewModelBase Unit { get; set; }

        public ViewModelBase Status { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Thông tin")]
        public string Info { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public ActionEnum Action { get; set; }

        public int Index { get; set; }

    }
}