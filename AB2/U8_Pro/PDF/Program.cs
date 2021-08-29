using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;

namespace U8_Pro_PDF
{
    class Program
    {
        public static string htmlAsset = @".\assets\spy_etf.html";

        static void Main(string[] args)
        {
            IronPdf.ChromePdfRenderer Renderer = new IronPdf.ChromePdfRenderer();
            Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
            Renderer.RenderingOptions.EnableJavaScript = true;
            Renderer.RenderingOptions.RenderDelay = 6000;   // Doesn't appear to do shit

            string path = @".\output\";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            // Lorem ipsum but with meat
            Console.WriteLine("Processing URL as PDF...");
            Renderer.RenderUrlAsPdf("https://baconipsum.com/api/?type=all-meat&paras=3&start-with-lorem=1&format=html").SaveAs(@".\output\LoremIpsum.pdf");

            // S&P 500 ETF
            Console.WriteLine("Processing HTML as PDF...");
            Renderer.RenderHTMLFileAsPdf(htmlAsset).SaveAs(@".\output\SPY_ETF-static.pdf");

            // Async renderer
            asyncHtmlRenderer();

            // Image
            Console.WriteLine("Processing image(s) as PDF...");
            var ImageFiles = System.IO.Directory.EnumerateFiles(@".\assets").Where(f => f.EndsWith(".jpg") || f.EndsWith(".jpeg"));
            ImageToPdfConverter.ImageToPdf(ImageFiles).SaveAs(@".\output\images.pdf");

            Console.WriteLine("All done.");
        }

        public static async Task asyncHtmlRenderer() {
            var Renderer2 = new IronPdf.ChromePdfRenderer();

            // Async renderer
            string htmlContent = System.IO.File.ReadAllText(htmlAsset);

            Console.WriteLine("Processing HTML as PDF (async)...");
            var doc = await Renderer2.RenderHtmlAsPdfAsync(htmlContent);
            doc.SaveAs(@".\output\SPY_ETF-async.pdf");
        }
    }
}
