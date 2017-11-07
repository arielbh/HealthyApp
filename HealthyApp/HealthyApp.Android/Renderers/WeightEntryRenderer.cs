using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HealthyApp.Controls;
using HealthyApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WeightEntry), typeof(WeightEntryRenderer))]

namespace HealthyApp.Droid.Renderers
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
                        Control.SetBackgroundColor(global::Android.Graphics.Color.LightCoral);
                    }
                    else
                    {
                        Control.SetBackgroundColor(global::Android.Graphics.Color.White);
                    }
                }
            }
        }
    }
}
