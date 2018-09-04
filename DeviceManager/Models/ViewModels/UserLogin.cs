using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public int IDRole { get; set; }
        public string Email { get; set; }

        public virtual Role Role { get; set; }
    }
}