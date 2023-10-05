using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DanisanT;
using DanisanT.Droid;
using DanisanT.Droid.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly:ExportRenderer(typeof (Entry),typeof(EntryRendererANDROİD))]
namespace DanisanT.Droid.CustomRenderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class EntryRendererANDROİD : EntryRenderer
    {

        /*
         protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
         {
             base.OnElementChanged(e);
             if (e.OldElement == null)
             {
                 var GradientDrawable = new GradientDrawable();
                 GradientDrawable.SetCornerRadius(60f);
                 GradientDrawable.SetStroke(5, Android.Graphics.Color.Gray);
                 GradientDrawable.SetColor(Android.Graphics.Color.LightGray);
                 Control.SetBackground(GradientDrawable);
                 Control.SetPadding(50,Control.PaddingTop,Control.PaddingRight,Control.PaddingBottom);
             }
         }
        */
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control.SetAllCaps(false);
                Control.Background = this.Resources.GetDrawable(Resource.Drawable.RoundedEntry);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}