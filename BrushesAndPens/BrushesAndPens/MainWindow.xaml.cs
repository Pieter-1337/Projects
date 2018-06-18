using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace BrushesAndPens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Below is the root directory of your project, if you use getCurrentDirectory you will get the debug folder instead of the root directory of the project
        //pack://application:,,,/ProjectName;component/
        string RootDirectory = "pack://application:,,,/BrushesAndPens;component/";
        
        public MainWindow()
        {
            InitializeComponent();
            SetColors();    
        }

        private void SetColors()
        {
            //Rect1
            Rect1.Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
            Rect1.StrokeDashArray.Add(2);
            Rect1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Red);
            Rect1.StrokeThickness = 2;

            //Rect2
            //Create new gradient to add to the fill of the rectangle
            LinearGradientBrush Rect2Gradient = new LinearGradientBrush();

            //Create Gradient start and endpoints
            Rect2Gradient.StartPoint = new Point(0, 0);
            Rect2Gradient.EndPoint = new Point(1, 1);

            //Create and add gradient stops
            GradientStop lightYellow = new GradientStop(Colors.LightYellow, 0.00);
            Rect2Gradient.GradientStops.Add(lightYellow);

            GradientStop whitish = new GradientStop(Colors.WhiteSmoke, 0.33);
            Rect2Gradient.GradientStops.Add(whitish);

            GradientStop lightBlue = new GradientStop(Colors.LightSkyBlue, 0.66);
            Rect2Gradient.GradientStops.Add(lightBlue);

            Rect2.Fill = Rect2Gradient;

            //Rect3
            //Create new gradient to add to the fill of the rectangle
            LinearGradientBrush Rect3Gradient = new LinearGradientBrush();

            //Create gradient start and endpoints
            Rect3Gradient.StartPoint = new Point(0, 0.5);
            Rect3Gradient.EndPoint = new Point(1, 0.5);

            //Create and add gradient stops
            GradientStop Pink = new GradientStop(Colors.LightPink, 0.0);
            Rect3Gradient.GradientStops.Add(Pink);

            GradientStop Lightblue = new GradientStop(Colors.LightBlue, 0.7);
            Rect3Gradient.GradientStops.Add(Lightblue);

            Rect3.Fill = Rect3Gradient;

            //Rect4
            //Create new Radialgradient to add to he fill of the rectangle
            RadialGradientBrush Rect4Gradient = new RadialGradientBrush();
            Rect4Gradient.GradientOrigin = new Point(0.5, 0.5);
            Rect4Gradient.Center = new Point(0.5, 0.5);


            //Create and add Gradient stops
            GradientStop Blue = new GradientStop(Colors.DarkBlue, 0.0);
            Rect4Gradient.GradientStops.Add(Blue);

            GradientStop White = new GradientStop(Colors.WhiteSmoke, 0.25);
            Rect4Gradient.GradientStops.Add(White);

            GradientStop Blue2 = new GradientStop(Colors.DarkBlue, 0.5);
            Rect4Gradient.GradientStops.Add(Blue2);

            GradientStop White2 = new GradientStop(Colors.WhiteSmoke, 0.75);
            Rect4Gradient.GradientStops.Add(White2);

            GradientStop Blue3 = new GradientStop(Colors.DarkBlue, 1.0);
            Rect4Gradient.GradientStops.Add(Blue3);

            Rect4.Fill = Rect4Gradient;

            //Rect5 In XAML

            //Rect6
            //Current Directory in the URI is a variable with the current Directory
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(RootDirectory + "Images/oog.png"));
            Rect6.Fill = imgBrush;

        }
    }
}
