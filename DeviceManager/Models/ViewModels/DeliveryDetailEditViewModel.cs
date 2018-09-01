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

        public int IDDevice { get; set; }

        public int Quantity { get; set; }

        public string DateExpires { get; set; }

        public string Note { get; set; }

        public Page Page { get; set; }

    }
}