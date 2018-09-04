﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeviceManager.Models.ViewModels
{
    public class AccountLoginViewModel
    {

        [Display(Name ="Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public string Password { get; set; }

    }
}