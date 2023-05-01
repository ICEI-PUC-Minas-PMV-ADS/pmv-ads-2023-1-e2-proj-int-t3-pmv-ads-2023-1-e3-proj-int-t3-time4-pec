using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SistemaHospitalar.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Login")]
        public string login { get; set; }

        [Display(Name = "Senha")]
        public string senha { get; set; }
    }
}
