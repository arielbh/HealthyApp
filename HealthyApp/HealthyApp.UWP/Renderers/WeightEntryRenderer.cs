using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using HealthyApp.Controls;
using HealthyApp.UWP.Renderers;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(WeightEntry), typeof(WeightEntryRenderer))]

namespace HealthyApp.UWP.Renderers
{
    public class WeightEntryRenderer : EntryRenderer
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
                        Control.Background = new SolidColorBrush(Colors.LightCoral);
                        Control.BackgroundFocusBrush = new SolidColorBrush(Colors.LightCoral);
                    }
                    else
                    {
                        Control.Background = new SolidColorBrush(Colors.White);
                        Control.BackgroundFocusBrush = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }
    }
}
