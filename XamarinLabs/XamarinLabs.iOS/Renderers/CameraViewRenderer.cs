using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinLabs.Controls;
using XamarinLabs.iOS.Renderers;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]
namespace XamarinLabs.iOS.Renderers
{
    public class CameraViewRenderer : ViewRenderer<CameraView, UICameraPreview>
    {
        UICameraPreview cameraPreview;

        public CameraViewRenderer()
        { 
        
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                cameraPreview.Tapped -= CameraPreview_Tapped;
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    //this.Frame = new CGRect(0, 0, this.Bounds.Width, this.Bounds.Height);
                    //this.Frame = Bounds;
                    cameraPreview = new UICameraPreview(e.NewElement.Camera);
                    SetNativeControl(cameraPreview);
                }
                cameraPreview.Tapped += CameraPreview_Tapped;
            }
        }

        private void CameraPreview_Tapped(object sender, EventArgs e)
        {
            if (cameraPreview.IsPreviewing)
            {
                cameraPreview.CaptureSession.StopRunning();
                cameraPreview.IsPreviewing = false;
            }
            else
            {
                cameraPreview.CaptureSession.StartRunning();
                cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                Control.CaptureSession.Dispose();
                Control.Dispose();
            }
        }
    }
}