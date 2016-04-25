using ChemistryAssistant.Chemical_Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChemistryAssistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {

        public static Boolean chemPageInitialized = false;

        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void MyStopWatch_BackRequested(object sender, BackRequestedEventArgs e)
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
                SystemNavigationManager.GetForCurrentView().BackRequested += MyStopWatch_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

        }

        private void ThirdGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //elements tapped
            Frame.Navigate(typeof(BrowsePage));
        }

        

        private void FourthGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //calculator tapped
            Frame.Navigate(typeof(CalculatorPage));
        }

        private void ScondGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //local notepad tapped
            Frame.Navigate(typeof(NotepadPage));
        }

       

        private void FirstGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //reactions tapped
            Frame.Navigate(typeof(ReactionsPage));
        }

        private void FifthGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //error/rel/% tapped
            Frame.Navigate(typeof(ErrorCalculator));
        }

        private void SixthGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //quick note tapped
            Frame.Navigate(typeof(QuickNotePage));
        }
    }
}
