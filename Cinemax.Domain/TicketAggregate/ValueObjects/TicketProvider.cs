using Cinemax.Domain.TicketAggregate.Entities;
using DinkToPdfColorMode = DinkToPdf.ColorMode;
using QRCoder;
using Aspose.Words;
using System.Reflection.Metadata;



namespace Cinemax.Infrastructure;
public class TicketProvider
{
    public byte[] GenerateTicket(string htmlTemplate, string cinemaxLogo, string backdroppath, Ticket ticket)
{
    string text = "id : " + ticket.Id.Value.ToString() + " " + "userId : " + (ticket.UserId?.Value.ToString() ?? "NULL") + " " + "seatId : " + ticket.SeatId.Value.ToString() + " " +"projectionId : " + ticket.ProjectionId.Value.ToString() + " " + "date : " + ticket.Date.ToString("dd/MM/yyyy HH:mm");
    byte[] logoBytes = System.IO.File.ReadAllBytes(cinemaxLogo);
    string logoBase64 = Convert.ToBase64String(logoBytes);
    byte[] backBytes = System.IO.File.ReadAllBytes(backdroppath);
    string backBase64 = Convert.ToBase64String(backBytes);
    
    var qrCodeImage = GenerateQRCode(text);
    var qrCodeBase64 = Convert.ToBase64String(qrCodeImage);
    var htmlWithQrCode = htmlTemplate
        .Replace("{{backdrop}}", $"data:image/png;base64,{backBase64}")
        .Replace("{{cinemaxLogo}}", $"data:image/png;base64,{logoBase64}")
        .Replace("{{sala}}", ticket.Projection.Room.Name )
        .Replace("{{asiento}}",(char) (ticket.Seat.Row + 65) + ticket.Seat.Colum.ToString() )
        .Replace("{{fecha}}", ticket.Date.ToString("dd/MM/yyyy"))
        .Replace("{{hora}}", ticket.Date.ToString("HH:mm"))
        .Replace("{{id}}", ticket.Id.Value.ToString())
        .Replace("{{pelicula}}", ticket.Projection.Movie.Name)
        .Replace("{{precio}}", ticket.Projection.Price.ToString())
        .Replace("{{qr}}", $"data:image/png;base64,{qrCodeBase64}");
    
    var pdf = ConvertHtmlToPdf(htmlWithQrCode);
    SavePdfToFile(pdf, "ticket.pdf");
    return pdf;
}

public void SavePdfToFile(byte[] pdfBytes, string fileName)
{
    // Obtén la ruta a la carpeta donde se está ejecutando tu aplicación.
    var applicationFolder = AppDomain.CurrentDomain.BaseDirectory;

    // Crea la ruta completa al archivo.
    var filePath = Path.Combine(applicationFolder, fileName);

    // Escribe los bytes en el archivo.
    File.WriteAllBytes(filePath, pdfBytes);
}

/*
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
        
    }*/

    public byte[] GenerateQRCode(string text)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);

        return qrCodeAsPngByteArr;
    }

    public byte[] ConvertHtmlToPdf(string html)
    {
        // Crea un nuevo documento de Aspose.Words.
        var doc = new Aspose.Words.Document();
        // Crea un nuevo nodo de documento.
        var builder = new DocumentBuilder(doc);
        // Inserta el HTML en el documento.
        builder.InsertHtml(html);
        // Guarda el documento en un stream de memoria como PDF.
        using (var stream = new MemoryStream())
        {
            doc.Save(stream, SaveFormat.Pdf);
            return stream.ToArray();
        }
    }
}
