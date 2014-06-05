using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using System.ComponentModel;
using DrawIt;
using DrawIt.WinPhone;

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer2))]

namespace DrawIt.WinPhone
{
    public class ImageWithTouchRenderer2 : ViewRenderer<Xamarin.Forms.Image, WPControls.Image>
    {
        protected override void OnModelChanged()
        {
            base.OnModelChanged();

            var currentView = (Image)Control;

            SetNativeControl(new DrawView(currentView.Context));
        }

        protected override void OnHandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnHandlePropertyChanged(sender, e);

            //if (e.PropertyName == ImageWithTouch.CurrentLineColorProperty.PropertyName)
            //{
            //    ((DrawView)Control).CurrentLineColor = ((ImageWithTouch)Model).CurrentLineColor.ToAndroid();
            //}
        }
    }
}
