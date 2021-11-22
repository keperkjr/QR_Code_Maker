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
        public async Task<IViewComponentResult> InvokeAsync(QR_Code_Maker.Models.QRCode qrCode = null)
        {
            var model = qrCode;
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
}
