using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Code_Maker.ViewComponents
{
    public class QRCodeViewer : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string source = null)
        {
            var data = Convert.ToBase64String(Utils.Methods.CreateQRCode(source));
            return await Task.FromResult((IViewComponentResult)View(model: data));
        }
    }
}
