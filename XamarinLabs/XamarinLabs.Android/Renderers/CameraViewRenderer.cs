using System;
using Android.Content;
using Android.Hardware;
using XamarinLabs.Droid;
using XamarinLabs.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinLabs.Controls;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraViewRenderer))]
namespace XamarinLabs.Droid.Renderers
{
    public class CameraViewRenderer : ViewRenderer<CameraView, CameraPreview>
    {
        CameraPreview cameraPreview;
        public CameraViewRenderer(Context context) : base(context)
        { 
        
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                cameraPreview = new CameraPreview(Context);
                SetNativeControl(cameraPreview);
            }
            Control.Preview = Camera.Open((int)e.NewElement.Camera);
            cameraPreview.Click += CameraPreview_Click;
            if (e.OldElement != null)
                cameraPreview.Click -= CameraPreview_Click;
        }

        private void CameraPreview_Click(object sender, EventArgs e)
        {
            if (cameraPreview.IsPreviewing)
            {
                cameraPreview.Preview.StopPreview();
                cameraPreview.IsPreviewing = false;
            }
            else
            {
                cameraPreview.Preview.StartPreview();
                cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                Control.Preview.Release();
            }
        }
    }
}