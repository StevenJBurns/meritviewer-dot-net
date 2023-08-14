using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace Ara.MeritViewer.View
  {
  public partial class WindowAbout : Window
    {
    private Random R;
    private XElement XE;
    private List<XElement> ImageList;

    public WindowAbout()
      {
      InitializeComponent();

      R = new Random();

      lblAssembly.Content = Assembly.GetExecutingAssembly().GetName().Name.ToString();
      lblVersion.Content = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

      foreach (XElement xe in Ara.MeritViewer.Data.ApplicationDataLayer.DataXML.Elements("Merit"))
        { ImageList.Add(xe); }

      GetRandomImage();
      }

      public WindowAbout(object datacontext, int seed)
        {
        InitializeComponent();

        R = new Random();

        lblAssembly.Content = Assembly.GetExecutingAssembly().GetName().Name.ToString();
        lblVersion.Content = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        XE = datacontext as XElement;
        ImageList = new List<XElement>();

        foreach (XElement xe in XE.Elements())
          { ImageList.Add(xe); }

        //GetRandomImage();
        }

        private void GetRandomImage()
          {
          XElement xe = ImageList[GetRandomIndex()];
          String str = xe.Attribute("imagepath").Value;

          imgRandomMerit.Source = new BitmapImage(new Uri(@"Images\" + str, UriKind.Relative));
          lblRandomMerit.Content = xe.Attribute("name").Value;
          }

          private void NextRandomImage(object sender, EventArgs e)
            {
            String str;
            XElement xe = ImageList[GetRandomIndex()];

            try
              {
              str = xe.Attribute("imagepath").Value;

              imgRandomMerit.Source = new BitmapImage(new Uri(@"Images\" + str, UriKind.Relative));
              lblRandomMerit.Content = xe.Attribute("name").Value;

              (FindResource("StoryboardFade") as Storyboard).Begin(imgRandomMerit);
              }
            catch (Exception)
              {
              xe = ImageList[R.Next(ImageList.Count - 1)];
              }
            finally
              {
              str = xe.Attribute("imagepath").Value;
              imgRandomMerit.Source = new BitmapImage(new Uri(@"Images\" + str, UriKind.Relative));
              }
            }

           private int GetRandomIndex()
             {
             if (ImageList.Count > -1)
               return new Random().Next(0, ImageList.Count - 1);
             else
               return 0;
      }
    }
  }
