namespace Cinemax.Application.Common.Interfaces.Services;
public interface ITicketProvider{
    Task<byte[]> GeneratePdfFromHtmlFile(string sala, 
            string asiento, string fecha, string hora, string id, string pelicula, string precio,
             string qrImagePath, string cinemaxLogoPath, string backdropImagePath);
}
