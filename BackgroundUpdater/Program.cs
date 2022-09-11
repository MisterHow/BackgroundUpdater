using BackgroundUpdater.Services;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;

namespace BackgroundUpdater
{
    static class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam,int flags);
        private static int SPI_SETDESKWALLPAPER = 20;
        private static int SPIF_UPDATEINIFILE = 0x1;
        static void Main()
        {
            NasaService nasaService = new NasaService();
            var imagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\background.png";
            var today = DateTime.Now;
            var APOD = nasaService.GetAPOD(today).GetAwaiter().GetResult();
            while (APOD.ImageUrl.Contains("youtube"))
            {
                APOD = nasaService.GetAPOD(today.AddDays(-1)).GetAwaiter().GetResult();
            }
            try
            {
                SaveImage(APOD.ImageUrl, imagePath, ImageFormat.Png);
            }
            catch (ExternalException ex)
            {
                Console.Write(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.Write(ex.Message);
            }
            try
            {
                SetImage(imagePath);
            }
            catch (ExternalException ex)
            {
                Console.Write(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.Write(ex.Message);
            }
        }
        private static void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
        private static void SetImage(string filename)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename, SPIF_UPDATEINIFILE);
        }
    }
}