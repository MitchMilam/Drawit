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

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]

namespace DrawIt.WinPhone
{
    public class ImageWithTouchRenderer
    {
        // TODO: Add renderer once the backend code from Xamarin becomes complete.

        //protected override void OnModelChanged()
        //{
        //    base.OnModelChanged();

        //    var currentView = (Image)Control;

        //    SetNativeControl(new DrawView(currentView.Context));
        //}

        //protected override void OnHandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnHandlePropertyChanged(sender, e);

        //    //if (e.PropertyName == ImageWithTouch.CurrentLineColorProperty.PropertyName)
        //    //{
        //    //    ((DrawView)Control).CurrentLineColor = ((ImageWithTouch)Model).CurrentLineColor.ToAndroid();
        //    //}
        //}
    }
}
