using System;
using Foundation;
using PdfKit;
using SampleApp.Controls;
using SampleApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(SamplePDFView), typeof(SamplePDFViewRenderer))]
namespace SampleApp.iOS.Renderers
{
    public class SamplePDFViewRenderer: ViewRenderer<SamplePDFView, PdfView>
    {
        private PdfView pdfView;

        protected override void OnElementChanged(ElementChangedEventArgs<SamplePDFView> e)
        {            
            if (pdfView==null)
            {
                var pdfFilePath = NSBundle.MainBundle.PathForResource("sample", "pdf");

                var pdfData =  NSData.FromFile(pdfFilePath);

                var doc = new PdfDocument(pdfData);

                pdfView = new PdfView();

                pdfView.Document = doc;
            }

            SetNativeControl(pdfView);
        }
    }
}
