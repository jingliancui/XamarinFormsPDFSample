using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Github.Barteksc.Pdfviewer;
using SampleApp.Controls;
using SampleApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SamplePDFView), typeof(SamplePDFViewRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class SamplePDFViewRenderer: ViewRenderer<SamplePDFView, Android.Widget.RelativeLayout>
    {
        public SamplePDFViewRenderer(Context context):base(context){}

        private PDFView pdfView;

        private Android.Widget.RelativeLayout uiLayout;

        protected override void OnElementChanged(ElementChangedEventArgs<SamplePDFView> e)
        {
            var layout = Inflate(Context, Resource.Layout.PDFLayout, null);
            if (pdfView == null)
            {
                uiLayout = layout as Android.Widget.RelativeLayout;
            }

            pdfView = uiLayout.FindViewById<PDFView>(Resource.Id.pdfView);

            pdfView.FromAsset("sample.pdf").Load();

            SetNativeControl(uiLayout);
        }
    }
}