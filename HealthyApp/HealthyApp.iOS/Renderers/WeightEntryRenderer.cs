
using System.ComponentModel;
using HealthyApp.Controls;
using HealthyApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WeightEntry), typeof(WeightEntryRenderer))]
namespace HealthyApp.iOS.Renderers
{
    class WeightEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Text")
            {
                if (!string.IsNullOrEmpty(Element.Text))
                {
                    var isValid = uint.TryParse(Element.Text, out uint number);
                    if (!isValid)
                    {
                        Control.BackgroundColor = UIColor.FromRGB(240, 128, 128);
                    }
                    else
                    {
                        Control.BackgroundColor = UIColor.FromRGB(255, 255, 255);

                    }
                }
            }
        }
    }
}