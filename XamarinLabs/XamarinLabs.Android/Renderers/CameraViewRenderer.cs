using System.Runtime.Remoting.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinLabs.Controls;
using XamarinLabs.Droid.Renderers;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]
namespace XamarinLabs.Droid.Renderers
{
    public class CameraViewRenderer : ViewRenderer
    {
        public CameraViewRenderer()
        { 
        
        }
    }
}