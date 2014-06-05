using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using DrawIt;
using DrawIt.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]
namespace DrawIt.iOS
{
    public class ImageWithTouchRenderer : ImageRenderer
    {
        protected override void OnModelSet(VisualElement model)
        {
            base.OnModelSet(model);

            SetNativeControl(new DrawView(Control.Frame));
        }

        protected override void OnHandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnHandlePropertyChanged(sender, e);

            if (e.PropertyName == ImageWithTouch.CurrentLineColorProperty.PropertyName)
            {
                ((DrawView)Control).CurrentLineColor = ((ImageWithTouch)Model).CurrentLineColor.ToUIColor();
            }
        }
    }
}

