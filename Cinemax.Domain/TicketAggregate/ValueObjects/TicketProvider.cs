using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using DinkToPdf;
using DinkToPdf.Contracts;
using Cinemax.Domain.TicketAggregate.Entities;
using ZXing.QrCode;
using DinkToPdfColorMode = DinkToPdf.ColorMode;

namespace Cinemax.Infrastructure;
public class TicketProvider
{
    private readonly IConverter _converter;

    public TicketProvider(IConverter converter) 
    {
        _converter = converter;
    }

    public byte[] GenerateTicket(string htmlTemplate, string cinemaxLogo, Ticket ticket)
{
    string text = "id : " + ticket.Id.ToString() + " " + "userId : " + ticket.UserId.ToString() + " " + "seatId : " + ticket.SeatId.ToString() + " " +"projectionId : " + ticket.ProjectionId.ToString() + " " + "date : " + ticket.Date.ToString("dd/MM/yyyy HH:mm");

    var qrCodeImage = GenerateQRCode(text);
    var qrCodeBase64 = Convert.ToBase64String(qrCodeImage);
    var htmlWithQrCode = htmlTemplate
        .Replace("{{cinemaxLogo}}", $"data:image/png;base64,{cinemaxLogo}")
        .Replace("{{sala}}", ticket.Projection.Room.Name )
        .Replace("{{asiento}}",(char) (ticket.Seat.Row + 65) + ticket.Seat.Colum.ToString() )
        .Replace("{{fecha}}", ticket.Date.ToString("dd/MM/yyyy"))
        .Replace("{{hora}}", ticket.Date.ToString("HH:mm"))
        .Replace("{{id}}", ticket.Id.ToString())
        .Replace("{{pelicula}}", ticket.Projection.Movie.Name)
        .Replace("{{precio}}", ticket.Projection.Price.ToString())
        .Replace("{{qr}}", $"data:image/png;base64,{qrCodeBase64}");
    var pdf = GeneratePdf(htmlWithQrCode);

    return pdf;
}

    private byte[] GenerateQRCode(string text)
    {
        var qrWriter = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = 200,
                Width = 200
            }
        };

        var pixelData = qrWriter.Write(text);
        var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);

        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
        
        try
        {
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
        

        var memoryStream = new MemoryStream();
        
        bitmap.Save(memoryStream, ImageFormat.Png);

        return memoryStream.ToArray();
        
    }

    private byte[] GeneratePdf(string html)
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = DinkToPdfColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = html,
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        return _converter.Convert(pdf);
    }
}