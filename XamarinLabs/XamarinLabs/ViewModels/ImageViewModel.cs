using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace XamarinLabs.ViewModels
{
    public class ImageViewModel: BaseViewModel
    {
        string myImage = string.Empty;
        public ICommand OpenCameraCommand { get; private set; }
        public string MyImage
        {
            get { return myImage; }
            set
            {
                SetProperty(ref myImage, value);
            }
        }

        public ImageViewModel()
        {
            OpenCameraCommand = new Command(OpenCamera);
        }

        private async void OpenCamera(object obj)
        {
            
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            var statusStorageRead = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (statusStorageRead != PermissionStatus.Granted)
            {
                statusStorageRead = await Permissions.RequestAsync<Permissions.StorageRead>();
            }
            var statusStorageWrite = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (statusStorageWrite != PermissionStatus.Granted)
            {
                statusStorageWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });
            if (file == null)
                return;

            await App.Current.MainPage.DisplayAlert("File Location", "Picture Taken", "OK");
            MyImage = file.Path;
        }
    }
}
