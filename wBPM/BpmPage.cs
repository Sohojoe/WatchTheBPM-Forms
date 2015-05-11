using System;
using Xamarin.Forms;
using BPM;


namespace wBPM
{
	public class BpmPage : ContentPage
	{
		static Color yellowColor = Color.FromHex("F2F119");
		static Color redColor = Color.FromHex("EF1729");

		Label bpmCounter = new Label {
			TextColor = yellowColor,
			FontSize = 100,
//			FontFamily = ""
			FontAttributes = FontAttributes.Bold,
			Text = "125",
			YAlign = TextAlignment.Center,
			XAlign = TextAlignment.Start,
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
		};
		Label bpmLogo = new Label {
			Text = "BPM",
			YAlign = TextAlignment.Center,
			XAlign = TextAlignment.End,
			HorizontalOptions = LayoutOptions.End,
			VerticalOptions = LayoutOptions.Center,
			TextColor = Color.White,
			FontSize = 40,
		};

		Grid topSection = new Grid {
			ColumnSpacing = 0,
			ColumnDefinitions = new ColumnDefinitionCollection{
				new ColumnDefinition{Width = new GridLength (1,GridUnitType.Star)},
				new ColumnDefinition{Width = GridLength.Auto},
			},
			VerticalOptions = LayoutOptions.Center,
		};
		Button tapButton = new Button{
//			Text = "tap!",
			Image = new FileImageSource{File="tap"},
			BackgroundColor = yellowColor,
			TextColor = redColor,
			BorderRadius = 15,
			FontSize = 33,
		};
		Grid grid = new Grid{
			Padding = new Thickness(10),
			RowSpacing = 0,
			RowDefinitions = new RowDefinitionCollection{
				new RowDefinition{Height = new GridLength (.5,GridUnitType.Star)},
				new RowDefinition{Height = new GridLength (.5,GridUnitType.Star)},
			}
		};

//		Label

		BPMModel bpmModel;
		public BpmPage ()
		{
			BackgroundColor = Color.Black;

//			bpmCounter.SetBinding(Label.TextProperty, nameof(bpmModel.AveBPMStr));
			tapButton.Clicked += (object sender, EventArgs e) => {
				bpmModel.RecordTap();
				bpmCounter.Text = bpmModel.AveBPMStr;
			};

			topSection.Children.Add (bpmCounter,0,0);
			topSection.Children.Add (bpmLogo,1,0);
			grid.Children.Add (topSection,0,0);
			grid.Children.Add (tapButton,0,1);
			Content = grid;
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			bpmModel = new BPMModel();
			BindingContext = bpmModel;
			bpmCounter.BindingContext = bpmModel;
		}
	}
}

