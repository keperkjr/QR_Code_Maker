using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Code_Maker.Models
{
    public class QRCode
    {
        [Required(ErrorMessage = "Please enter a url or text")]
        public string source { get; set; }
    }
}
