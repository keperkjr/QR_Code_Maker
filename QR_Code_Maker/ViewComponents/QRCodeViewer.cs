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
        public async Task<IViewComponentResult> InvokeAsync(string source = null, int size = 100)
        {
            var data = Convert.ToBase64String(Utils.Methods.CreateQRCode(source, size, size));
            return await Task.FromResult((IViewComponentResult)View(model: data));
        }
    }
}
