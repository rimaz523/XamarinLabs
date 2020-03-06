using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinLabs.Models;

namespace XamarinLabs.Helpers
{
    public class ReportTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CompletedTemplate { get; set; }
        public DataTemplate IncompleteTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Report)item).IsCompleted ? CompletedTemplate : IncompleteTemplate;
        }
    }
}
