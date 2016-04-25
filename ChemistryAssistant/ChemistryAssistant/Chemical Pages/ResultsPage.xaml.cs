using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChemistryAssistant.Chemical_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultsPage : Page
    {
        

        public ResultsPage()
        {
            this.InitializeComponent();
            updateForm();
            //this.SizeChanged += CarbonPage_SizeChanged;
            //scrollViewer.Height = Window.Current.Bounds.Height;

         
        }

        //private void CarbonPage_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    scrollViewer.Height = Window.Current.Bounds.Height;
        //}



        //back request navigation start
        private void ResultsPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                SystemNavigationManager.GetForCurrentView().BackRequested += ResultsPage_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

        }//nav end


        private async void updateForm()
        {


            try
            {
                HttpClient client = new HttpClient();

                //HttpResponseMessage response = await client.GetAsync("https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Carbon");

                HttpResponseMessage response = await client.GetAsync(BrowsePage.url);
                string url = await response.Content.ReadAsStringAsync();

                //char[] delimiters = new char[] {'\\', '"', '{', '}' };
                char[] delimiters = new char[] { ' ', '\\', '"', '{', '}' };
                var split = url.Split(delimiters);

                var extractString = "";
                var titleString = "";

                int extractIndex = 0;

                for (int i = 0; i < split.Length; i++)
                {
                    //Get title
                    if (split[i].Contains("title")) titleString = split[i + 2];


                    //Get extract
                    if (split[i].Contains("extract")) extractIndex = i + 2; //2
                    if (i >= extractIndex && extractIndex != 0) extractString += split[i] + " ";


                }

                //using regex to get rid off words i dont want to see on screen(not supported characters).
                string newName = Regex.Replace(extractString, @Exceptions.excluded, "");
                //adding new line after evert "." (replacing . with . and adding new line)
                newName = newName.Replace(".", "." + System.Environment.NewLine);
                this.title.Text = titleString;
                this.extract.Text = newName; //extractString



                //BitmapImage bm = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/f/f0/Graphite-and-diamond-with-scale.jpg"));

                BitmapImage bm = new BitmapImage(new Uri(BrowsePage.img));
                image1.Source = bm;
                

                
            }
            catch (Exception)
            {
                MessageDialog dialog = new MessageDialog("Could not connect to Internet, please check your connection.");
                await dialog.ShowAsync();
                
            }
        }

        //private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    extract.Height = mainGrid.Height / 2;
        //}
    }

}

