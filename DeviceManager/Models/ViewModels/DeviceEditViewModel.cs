using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class DeviceEditViewModel : ViewModelBase
    {

        public string UnitName { get; set; }

        public int Quantity { get; set; }

        public int IDReceipt { get; set; }

        public ViewModelBase Category { get; set; }

        public ViewModelBase Unit { get; set; }

        public ViewModelBase Status { get; set; }

        public decimal Price { get; set; }

        public string Info { get; set; }

        public string Note { get; set; }

        public ActionEnum Action { get; set; }

    }
}