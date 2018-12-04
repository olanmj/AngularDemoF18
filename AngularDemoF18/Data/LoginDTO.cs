using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemoF18.Data
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
    }
}
