using System;
using System.Windows;
using System.Windows.Media.Effects;

namespace Ara.MeritViewer.View
  {
  public partial class WindowMain : Window
    {
    public WindowMain()
      { InitializeComponent(); }

    private void ButtonClick_Display(object sender, RoutedEventArgs e)
      {
      BlurEffect blur = new BlurEffect() { Radius = 10 };
      WindowDisplay winDisplay = new WindowDisplay()
        {
        Owner = this,
        Icon = this.Icon,
        BorderBrush = this.BorderBrush,
        Background = this.Background
        };

      this.Effect = blur;
      winDisplay.ShowDialog();
      this.Effect = null;
      }

    private void ButtonClick_Options(object sender, RoutedEventArgs e)
      {
      BlurEffect blur = new BlurEffect() { Radius = 10 };
      WindowOptions winOptions = new WindowOptions()
        {
        Owner = this,
        Icon = this.Icon,
        BorderBrush = this.BorderBrush,
        Background = this.Background
        };

      this.Effect = blur;
      winOptions.ShowDialog();
      this.Effect = null;
      }

    private void ButtonClick_About(object sender, RoutedEventArgs e)
      {
      BlurEffect blur = new BlurEffect() { Radius = 10 };

      WindowAbout winAbout = new WindowAbout()
        {
        Owner = this,
        Icon = this.Icon,
        BorderBrush = this.BorderBrush,
        Background = this.Background,
        DataContext = this.DataContext
        };

      this.Effect = blur;
      winAbout.ShowDialog();
      this.Effect = null;
      }

    private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {

      }
    }
  }

