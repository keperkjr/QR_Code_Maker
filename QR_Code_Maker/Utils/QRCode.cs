// ============================================================================
//    Author: Kenneth Perkins
//    Date:   May 13, 2021
//    Taken From: http://programmingnotes.org/
//    File:  Utils.cs
//    Description: Handles general utility functions
// ============================================================================
using System;

namespace Utils {
    public static class Methods {
        /// <summary>
        /// Converts a string and encodes it to a QR code byte array
        /// </summary>
        /// <param name="data">The data to encode</param>
        /// <param name="height">The height of the QR code</param>
        /// <param name="width">The width of the QR code</param>
        /// <param name="margin">The margin around the QR code</param>
        /// <returns>The byte array of the data encoded into a QR code</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static byte[] CreateQRCode(string data, int height = 100
                        , int width = 100, int margin = 0) {
            byte[] bytes = null;
            var barcodeWriter = new ZXing.BarcodeWriter() {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions() {
                    Height = height, Width = width, Margin = margin
                }
            };
            using (var image = barcodeWriter.Write(data)) {
                using (var stream = new System.IO.MemoryStream()) {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    bytes = stream.ToArray();
                }
            }
            return bytes;
        }


        /// <summary>
        /// Converts a QR code and decodes it to its string data 
        /// </summary>
        /// <param name="bytes">The QR code byte array</param> 
        /// <returns>The string data decoded from the QR code</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static string ReadQRCode(byte[] bytes) {
            var result = string.Empty;
            using (var stream = new System.IO.MemoryStream(bytes)) {
                using (var image = System.Drawing.Image.FromStream(stream)) {
                    var barcodeReader = new ZXing.BarcodeReader();
                    var decoded = barcodeReader.Decode((System.Drawing.Bitmap)image);
                    if (decoded != null) { 
                        result = decoded.Text;
                    }
                }
            }
            return result;
        }
    }
}// http://programmingnotes.org/