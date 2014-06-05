using Xamarin.Forms;

namespace DrawIt
{
	public class ImageWithTouch : Image 
	{
		public static readonly BindableProperty CurrentLineColorProperty = BindableProperty.Create ((ImageWithTouch w) => w.CurrentLineColor, Color.Default);

		public Color CurrentLineColor {
			get {
				return (Color)GetValue (CurrentLineColorProperty);
			}
			set {
				SetValue (CurrentLineColorProperty, value);
			}
		}
	}
}

