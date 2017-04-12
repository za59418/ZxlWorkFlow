using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Zxl.WebSite.ModelView
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        [StringLength(10, ErrorMessage = "必须至少包含{2}个字符", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "记住我？")]
        public bool RememberMe { get; set; }
    }
}