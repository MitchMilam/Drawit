using System.Windows.Media;
using DrawIt;
using DrawIt.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]

namespace DrawIt.WinPhone
{
    public class ImageWithTouchRenderer : ViewRenderer<ImageWithTouch, DrawView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ImageWithTouch> e)
        {
            base.OnElementChanged(e);

            SetNativeControl(new DrawView());
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
            var converter = new ColorConverter();

            Control.CurrentBrush =
                (SolidColorBrush)
                    converter.Convert(Element.CurrentLineColor, null, null, null);
        }
    }
}
