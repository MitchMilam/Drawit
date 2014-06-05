using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using DrawIt;
using DrawIt.Android;

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]

namespace DrawIt.Android
{
    public class ImageWithTouchRenderer : ImageRenderer
    {
        // Override the OnModelChanged method so we can tweak this renderer post-initial setup
        protected override void OnModelChanged(VisualElement oldModel, VisualElement newModel)
        {
            base.OnModelChanged(oldModel, newModel);

            var currentView = (global::Android.Widget.ImageView)Control;

            SetNativeControl(new DrawView(currentView.Context));
        }

        protected override void OnHandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnHandlePropertyChanged(sender, e);

            if (e.PropertyName == ImageWithTouch.CurrentLineColorProperty.PropertyName)
            {
                ((DrawView)Control).CurrentLineColor = ((ImageWithTouch)Model).CurrentLineColor.ToAndroid();
            }
        }
    }
}

