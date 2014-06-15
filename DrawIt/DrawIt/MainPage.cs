using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DrawIt
{
    class MainPage : ContentPage
    {
        private const int PalleteSpacing = 3;
        private ImageWithTouch DrawingImage;
        private Dictionary<string, Color> ColorPallete;

        public MainPage()
        {
            Content = BuildGrid();

            // Accomodate iPhone status bar.
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 10);
        }

        private Grid BuildGrid()
        {
            return new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions = {
					new RowDefinition {
						Height = GridLength.Auto
					},
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					},
				},
                ColumnDefinitions = {
					new ColumnDefinition {
						Width = new GridLength (100, GridUnitType.Absolute)
					},
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},
				},
                Children =
                {
                  {new Label {
				        Text = "Draw It",
				        Font = Font.BoldSystemFontOfSize (50),
				        HorizontalOptions = LayoutOptions.CenterAndExpand,
				        VerticalOptions = LayoutOptions.FillAndExpand
	        		    }, 0, 2, 0, 1},
                  {BuildPalletFrame(), 0, 1},
                  {new ContentView {
                       Content = BuildDrawingFrame(),
                       Padding = new Thickness(10, 0, 0, 0),
                       HorizontalOptions = LayoutOptions.FillAndExpand,
                       VerticalOptions = LayoutOptions.FillAndExpand
                  }, 1, 1}
                }
            };
        }

        private StackLayout CreatePalletStack()
        {
            BuildColorPallete();

            var stack = new StackLayout
            {
                Spacing = PalleteSpacing,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            stack.SizeChanged += OnStackSizeChanged;

            foreach (var button in ColorPallete.Select(color => new Button
            {
                Text = color.Key,
                TextColor = GetTextColor(color.Value),
                BackgroundColor = color.Value,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
            }))
            {
                button.Clicked += OnButtonClicked;

                stack.Children.Add(button);
            }

            return stack;
        }

        // Formula for computing Luminance out of R G B, which is something close to luminance = (red * 0.3) + (green * 0.6) + (blue * 0.1).
        // Original Source: http://stackoverflow.com/questions/20978198/how-to-match-uilabels-textcolor-to-its-background
        private static Color GetTextColor(Color backgroundColor)
        {
            var backgroundColorDelta = ((backgroundColor.R*0.3) + (backgroundColor.G*0.6) + (backgroundColor.B*0.1));

            return (backgroundColorDelta > 0.4f) ? Color.Black : Color.White;
        }

        private Frame BuildPalletFrame()
        {
            var palleteFrame = new Frame
            {
                BackgroundColor = Color.White,
                Padding = 5,
                Content = CreatePalletStack()
            };

            return palleteFrame;
        }

        private Frame BuildDrawingFrame()
        {
            DrawingImage = new ImageWithTouch
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                CurrentLineColor = Color.Black
            };

            DrawingImage.SetBinding(ImageWithTouch.CurrentLineColorProperty, "CurrentLineColor");

            var palleteFrame = new Frame
            {
                BackgroundColor = Color.White,
                Padding = 5,
                HasShadow = false,
                OutlineColor = Color.Black,
                Content = DrawingImage
            };

            return palleteFrame;
        }

        private void BuildColorPallete()
        {
            ColorPallete = new Dictionary<string, Color>
			{
				{ "White", Color.White },
				{ "Silver", Color.Silver },
				{ "Gray", Color.Gray },
				{ "Yellow", Color.Yellow },
				{ "Aqua", Color.Aqua },
				{ "Blue", Color.Blue },
				{ "Navy", Color.Navy },
				{ "Lime", Color.Lime },
				{ "Green", Color.Green },
				{ "Teal", Color.Teal },
				{ "Olive", Color.Olive },
				{ "Fuschia", Color.Fuschia },
				{ "Red", Color.Red },
				{ "Purple", Color.Purple },
				{ "Maroon", Color.Maroon },
				{ "Black", Color.Black },
			};
        }

        #region Event Handlers

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            DrawingImage.CurrentLineColor = button.BackgroundColor;
        }

        private void OnStackSizeChanged(object sender, EventArgs args)
        {
            var stackLayout = (StackLayout)sender;

            var width = stackLayout.Width;
            var height = stackLayout.Height;

            if (width <= 0 || height <= 0)
            {
                return;
            }

            var stackChildSize = height / stackLayout.Children.Count;
            var font = Font.BoldSystemFontOfSize(0.4 * stackChildSize);

            foreach (var button in stackLayout.Children.Cast<Button>())
            {
                button.Font = font;

                button.HeightRequest = stackChildSize - PalleteSpacing;
            }
        }

        #endregion

    }
}


