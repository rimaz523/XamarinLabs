using Xamarin.Forms;

namespace XamarinLabs.Controls
{
    public class CameraView : View
    {
        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
            propertyName: "Camera", 
            returnType: typeof(CameraOptions),
            declaringType: typeof(CameraView),
            defaultValue: CameraOptions.Rear);

        public CameraOptions Camera
        { 
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }

        public CameraView()
        { 
            
        }
    }

    public enum CameraOptions
    { 
        Front,
        Rear
    }
}
