using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamicListViewSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Model> imgList;
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            imgList = new List<Model>();
            imgList.Add(new Model
            {
                 ImageSource=new Uri("ms-appx:///SampleImages/image01.png"),
                 GridWidth=lvImgs.Width
            });
            imgList.Add(new Model
            {
                ImageSource = new Uri("ms-appx:///SampleImages/image02.png"),
                GridWidth = lvImgs.Width
            });
            imgList.Add(new Model
            {
                ImageSource = new Uri("ms-appx:///SampleImages/image03.jpg"),
                GridWidth = lvImgs.Width
            });
            imgList.Add(new Model
            {
                ImageSource = new Uri("ms-appx:///SampleImages/image04.jpg"),
                GridWidth = lvImgs.Width
            });
            lvImgs.ItemsSource=imgList;
            base.OnNavigatedTo(e);
        }

        private void CoreWindow_SizeChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
        {
            var widnowWidth = args.Size.Width;
            foreach (Model item in lvImgs.Items)
            {
                item.GridWidth = 500;
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            foreach (Model item in lvImgs.Items)
            {
                item.GridWidth = 500;
            }
        }
    }

    public class Model:INotifyPropertyChanged
    {
        public Uri ImageSource{get;set;}
        public double _gridWidth;
        public double GridWidth
        {
            get { return _gridWidth; }
            set {
                _gridWidth = value;
                RaisePropertyChanged();
            }
        }

        public void RaisePropertyChanged([CallerMemberName]string name="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    
}
