using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using AVFoundation;
using CoreGraphics;
using XamarinLabs.Controls;

namespace XamarinLabs.iOS
{
    public class UICameraPreview : UIView
    {
        AVCaptureVideoPreviewLayer previewLayer;
        CameraOptions cameraOptions;
        public AVCaptureSession CaptureSession { get; private set; }
        public bool IsPreviewing { get; set; }
        public event EventHandler<EventArgs> Tapped;

        public UICameraPreview(CameraOptions options)
        {
            cameraOptions = options;
            IsPreviewing = false;
            Initialize();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (previewLayer != null)
                previewLayer.Frame = this.Bounds;
        }

        void Initialize()
        {
            CaptureSession = new AVCaptureSession();
            previewLayer = new AVCaptureVideoPreviewLayer(CaptureSession)
            {
                Frame = Bounds,
                VideoGravity = AVLayerVideoGravity.ResizeAspectFill
            };
            var videoDevices = AVCaptureDevice.DevicesWithMediaType(AVMediaType.Video);
            var cameraPosition = (cameraOptions == CameraOptions.Front) ? AVCaptureDevicePosition.Front : AVCaptureDevicePosition.Back;
            var device = videoDevices.FirstOrDefault(d => d.Position == cameraPosition);
            if (device == null)
                return;
            NSError error;
            var input = new AVCaptureDeviceInput(device, out error);
            CaptureSession.AddInput(input);
            Layer.AddSublayer(previewLayer);
            CaptureSession.StartRunning();
            IsPreviewing = true;
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            OnTapped();
        }

        protected virtual void OnTapped()
        {
            var eventHandler = Tapped;
            if (eventHandler != null)
                eventHandler(this, new EventArgs());
        }
    }
}