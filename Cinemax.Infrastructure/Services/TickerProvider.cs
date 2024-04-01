using Cinemax.Application.Common.Interfaces.Services;

using DinkToPdf;
using QRCoder;
using System.Drawing.Imaging;

namespace Cinemax.Infrastructure.Services;
public class TicketProvider : ITicketProvider
{

    public async Task<byte[]> GeneratePdfFromHtmlFile(string sala, string asiento, string fecha, string hora, string id, string pelicula, string precio, string qrImagePath, string cinemaxLogoPath, string backdropImagePath)
    {
        using (var qrGenerator = new QRCodeGenerator())
        {
            var qrCodeData = qrGenerator.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("qr.png", ImageFormat.Png);
        }

        var converter = new SynchronizedConverter(new PdfTools());
        string html = File.ReadAllText("TicketTemplate.html");

        html = html.Replace("{{sala}}", sala);
        html = html.Replace("{{asiento}}", asiento);
        html = html.Replace("{{fecha}}", fecha);
        html = html.Replace("{{hora}}", hora);
        html = html.Replace("{{id}}", id);
        html = html.Replace("{{pelicula}}", pelicula);
        html = html.Replace("{{precio}}", precio);
        html = html.Replace("{{qr}}", qrImagePath);
        html = html.Replace("{{cinemaxLogo}}", cinemaxLogoPath);
        html = html.Replace("{{backdrop}}", backdropImagePath);

        var doc = new HtmlToPdfDocument()
        {
            GlobalSettings = {
                ColorMode = DinkToPdf.ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            },
            Objects = {
                new ObjectSettings() {
                    HtmlContent = html,
                }
            }
        };

        return await Task.Run(() => converter.Convert(doc));
    }

}