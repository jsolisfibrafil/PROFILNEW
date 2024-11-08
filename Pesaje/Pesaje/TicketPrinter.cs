using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BarcodeStandard;
using SkiaSharp;
using System.IO;


namespace Pesaje
{
    public class TicketPrinter
    {
        private string line1;
        //private string line2;
        private Image barcodeImage;
        private string line3;
        private string line4;
        private string line5;
        private string line6;


        // Constructor que recibe las dos líneas de texto
        public TicketPrinter(string line1, string line2, string line3, string line4, string line5, string line6)
        {   
            this.line1 = line1;
            this.barcodeImage = GenerateBarcode(line2) ;
            this.line3 = line3;
            this.line4 = line4;
            this.line5 = line5;
            this.line6 = line6;

        }
        //private Image GenerateBarcode(string text)
        //{
        //    Barcode barcode = new Barcode();
        //    barcode.IncludeLabel = true;  // Opcional: agrega una etiqueta con el texto debajo del código de barras
        //    barcode.Alignment = BarcodeStandard.AlignmentPositions.Center;// BarcodeLib.AlignmentPositions.CENTER;
        //    barcode.LabelFont = new Font("Arial", 10); // Tamaño de la fuente de la etiqueta

        //    // Generar el código de barras como imagen
        //    Image img = barcode.Encode(TYPE.CODE128, text, Color.Black, Color.White, 150, 50);
        //    return img;
        //}

        private Image GenerateBarcode(string text)
        {
            Barcode barcode = new Barcode();
            // Generar el código de barras como imagen en formato CODE128
            //Image img = barcode.GenerateBarcode .Encode(BarcodeStandard.Type.Code128, text, 150, 50); //.Encode(BarcodeStandard.Type.Code128, text, 150, 50);
            Image img = ConvertSKImageToImage(barcode.Encode(BarcodeStandard.Type.Code128, text, 250, 75));
            return img;
        }
        public Image ConvertSKImageToImage(SKImage skImage)
        {
            // Convierte SKImage a un arreglo de bytes
            using (var data = skImage.Encode(SKEncodedImageFormat.Png, 200))
            {
                byte[] imageBytes = data.ToArray();

                // Convierte el arreglo de bytes en un objeto System.Drawing.Image
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }

        // Método para imprimir el ticket sin necesidad de interactuar con la UI
        public void PrintTicket()
        {
            // Creamos una instancia de PrintDocument
            PrintDocument printDocument = new PrintDocument();

            // Asignamos el evento PrintPage para imprimir el contenido del ticket
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Inicia la impresión
            printDocument.Print();
        }

        // El evento PrintPage se encarga de dibujar el contenido en el ticket
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Se definen las fuentes para las dos líneas de texto
            Font font1 = new Font("Arial", 6, FontStyle.Regular);   // Fuente para la primera línea
            //Font font2 = new Font("Arial", 10, FontStyle.Bold);       // Fuente para la segunda línea
            Font font3 = new Font("Arial", 10, FontStyle.Regular);   // Fuente para la 3 línea
            Font font4 = new Font("Arial", 30, FontStyle.Regular);   // Fuente para la 4 línea
            Font font5 = new Font("Arial", 6, FontStyle.Regular);   // Fuente para la 5 línea
            Font font6 = new Font("Arial", 6, FontStyle.Regular);   // Fuente para la 6 línea


            // Dibuja las dos líneas en el ticket con tamaños de fuente distintos
            e.Graphics.DrawString(line1, font1, Brushes.Black, new PointF(5, 10));  // Primera línea
            
            //e.Graphics.DrawString(line2, font2, Brushes.Black, new PointF(5, 65));  // Segunda línea
            if (barcodeImage != null)
            {
                e.Graphics.DrawImage(barcodeImage, new PointF(-20, 30));
            }


            e.Graphics.DrawString(line3, font3, Brushes.Black, new PointF(20, 110));  // 3 línea
            e.Graphics.DrawString(line4, font4, Brushes.Black, new PointF(5, 130));  // 4 línea
            e.Graphics.DrawString(line5, font5, Brushes.Black, new PointF(0, 190));  // 5 línea
            e.Graphics.DrawString(line6, font6, Brushes.Black, new PointF(0, 205));  // 6 línea



        }
    }

}
