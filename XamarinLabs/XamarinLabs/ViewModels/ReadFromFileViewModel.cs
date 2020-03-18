using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLabs.ViewModels
{
    public class ReadFromFileViewModel
    {
        public string FileContents { get; set; }
        public string SystemPath { get; set; }

        public ReadFromFileViewModel()
        {
            FileContents = Files.OpenSharedFile();
            SystemPath = Files.getDocuments();
        }
    }
}
