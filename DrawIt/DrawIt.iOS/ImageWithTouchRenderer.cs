using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using DrawIt;
using DrawIt.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]
namespace DrawIt.iOS
{
    public class ImageWithTouchRenderer : ViewRenderer<ImageWithTouch, DrawView> 
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ImageWithTouch> e)
        {
            base.OnElementChanged(e);

            SetNativeControl(new DrawView(RectangleF.Empty));
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ImageWithTouch.CurrentLineColorProperty.PropertyName)
            {
                UpdateControl();
            }
        }

        private void UpdateControl()
        {
            Control.CurrentLineColor = Element.CurrentLineColor.ToUIColor();
        }
    }
}

