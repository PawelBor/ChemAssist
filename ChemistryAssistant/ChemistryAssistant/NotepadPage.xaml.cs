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
    public sealed partial class NotepadPage : Page
    {
        public Library Library = new Library();
        public NotepadPage()
        {
            this.InitializeComponent();
        }


        //back request navigation start
        private void NotepadPage_BackRequested(object sender, BackRequestedEventArgs e)
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
                SystemNavigationManager.GetForCurrentView().BackRequested += NotepadPage_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

        }//nav end

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Library.New(Display);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Library.Save(Display);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Library.Open(Display);
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            Bold.IsChecked = Library.Bold(ref Display);
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            Italic.IsChecked = Library.Italic(ref Display);
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            Underline.IsChecked = Library.Underline(ref Display);
        }

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Library.Size(ref Display, ref Size);
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            Left.IsChecked = Library.Left(ref Display);
            Centre.IsChecked = false;
            Right.IsChecked = false;

        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            Right.IsChecked = Library.Right(ref Display);
            Centre.IsChecked = false;
            Right.IsChecked = false;
        }



        private void Center_Click(object sender, RoutedEventArgs e)
        {
            Centre.IsChecked = Library.Centre(ref Display);
            Right.IsChecked = false;
            Left.IsChecked = false;
        }
    }
}
