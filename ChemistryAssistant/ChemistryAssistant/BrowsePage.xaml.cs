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
    public sealed partial class BrowsePage : Page
    {
        //public strings, used to send over content(links) to another page
        public static string url;
        public static string img;
        public static string txtDescriptionFrancium;

        public BrowsePage()
        {
            this.InitializeComponent();
        }

        

        private void BrowsePage_BackRequested(object sender, BackRequestedEventArgs e)
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
                SystemNavigationManager.GetForCurrentView().BackRequested += BrowsePage_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

        }

        //private void btnCarbon_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(Chemical_Pages.CarbonPage));
        //}

        private void lsvLithium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Lithium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Lithium_paraffin.jpg/220px-Lithium_paraffin.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSodium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Sodium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/Na_%28Sodium%29.jpg/220px-Na_%28Sodium%29.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPotassium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Potassium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Potassium-2.jpg/220px-Potassium-2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRubidium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Rubidium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c9/Rb5.JPG/220px-Rb5.JPG";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCaesium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Caesium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Cesium.jpg/220px-Cesium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvFrancium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Francium";
            img = "https://upload.wikimedia.org/wikipedia/en/thumb/9/92/Fr%2C87.jpg/150px-Fr%2C87.jpg";
            txtDescriptionFrancium = "Heat image of 300,000 francium atoms in a magneto-optical trap";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        //################################ALKALINE EARTH METALS################################

        private void lsvBerylium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Berylium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Be-140g.jpg/150px-Be-140g.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvMegnesium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Magnesium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/CSIRO_ScienceImage_2893_Crystalised_magnesium.jpg/220px-CSIRO_ScienceImage_2893_Crystalised_magnesium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCalcium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Calcium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Calcium_unter_Argon_Schutzgasatmosph%C3%A4re.jpg/220px-Calcium_unter_Argon_Schutzgasatmosph%C3%A4re.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvStrontium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Strontium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/Strontium_destilled_crystals.jpg/220px-Strontium_destilled_crystals.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvBarium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Barium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Barium_unter_Argon_Schutzgas_Atmosph%C3%A4re.jpg/220px-Barium_unter_Argon_Schutzgas_Atmosph%C3%A4re.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRadium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Radium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/Radium226.jpg/220px-Radium226.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }



        //################################LANTHANIDE################################
        private void lsvLanthanum_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Lanthanum";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8c/Lanthanum-2.jpg/220px-Lanthanum-2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCerium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Cerium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Cerium2.jpg/220px-Cerium2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPraseodymium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Praseodymium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/Praseodymium.jpg/220px-Praseodymium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvNeodymium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Neodymium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Neodymium2.jpg/220px-Neodymium2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPromethium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Promethium";
            img = "http://upload.wikimedia.org/wikipedia/commons/6/60/Electron_shell_061_promethium.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSamarium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Samarium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Samarium-2.jpg/220px-Samarium-2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvEuropium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Europium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Europium.jpg/220px-Europium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvGadolinium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Gadolinium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Gadolinium-4.jpg/220px-Gadolinium-4.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTerbium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Terbium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Terbium-2.jpg/220px-Terbium-2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvDysprosium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Dysprosium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Dy_chips.jpg/220px-Dy_chips.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvHolmium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Holmium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Holmium2.jpg/220px-Holmium2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvErbium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Erbium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Erbium-crop.jpg/220px-Erbium-crop.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvThulium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Thulium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Thulium_sublimed_dendritic_and_1cm3_cube.jpg/220px-Thulium_sublimed_dendritic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvYtterbium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Ytterbium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Ytterbium-3.jpg/220px-Ytterbium-3.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }


        //################################ACTINIDE################################

        private void lsvLutetium_Tapped(object sender, TappedRoutedEventArgs e) // one up wrong position
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Lutetium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Lutetium_sublimed_dendritic_and_1cm3_cube.jpg/220px-Lutetium_sublimed_dendritic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvActinium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Actinium";
            img = "https://upload.wikimedia.org/wikipedia/en/thumb/f/f3/Actinium.jpg/220px-Actinium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvThorium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Thorium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Thorium_sample_0.1g.jpg/220px-Thorium_sample_0.1g.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvProtactinium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Protactinium";
            img = "https://upload.wikimedia.org/wikipedia/en/thumb/0/05/Protactinium.jpg/220px-Protactinium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvUranium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Uranium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/HEUraniumC.jpg/220px-HEUraniumC.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvNeptunium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Neptunium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Neptunium2.jpg/220px-Neptunium2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPlutonium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Plutonium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/98/Plutonium3.jpg/220px-Plutonium3.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvAmericium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Americium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Americium_microscope.jpg/220px-Americium_microscope.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCurium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Curium";
            img = "https://upload.wikimedia.org/wikipedia/en/thumb/6/69/Curium.jpg/220px-Curium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvBerkelium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Berkelium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Berkelium_metal.jpg/220px-Berkelium_metal.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCalifornium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Californium";
            img = "https://upload.wikimedia.org/wikipedia/commons/9/93/Californium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvEinsteinium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Einsteinium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Einsteinium.jpg/220px-Einsteinium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvFermium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Fermium";
            img = "http://images.encyclopedia.com/utility/image.aspx?id=2795305&imagetype=Manual&height=300&width=300";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvMendelevium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Mendelevium";
            img = "https://upload.wikimedia.org/wikipedia/commons/d/dc/Electron_shell_101_Mendelevium.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvNobelium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Nobelium";
            img = "https://upload.wikimedia.org/wikipedia/commons/f/f5/Electron_shell_102_nobelium.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }


        //#########################TRANSITION METAL################################

        private void lsvScandium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Scandium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Scandium_sublimed_dendritic_and_1cm3_cube.jpg/220px-Scandium_sublimed_dendritic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTitanium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Titanium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/db/Titan-crystal_bar.JPG/220px-Titan-crystal_bar.JPG";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvVanadium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Vanadium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/98/Vanadium_etched.jpg/220px-Vanadium_etched.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvChromium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Chromium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Chromium_crystals_and_1cm3_cube.jpg/220px-Chromium_crystals_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvManganese_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Manganese";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Mangan_1-crop.jpg/220px-Mangan_1-crop.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvIron_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Iron";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Iron_electrolytic_and_1cm3_cube.jpg/220px-Iron_electrolytic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCobalt_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Cobalt";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Kobalt_electrolytic_and_1cm3_cube.jpg/220px-Kobalt_electrolytic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvNickel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Nickel";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/57/Nickel_chunk.jpg/220px-Nickel_chunk.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCopper_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Copper";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f0/NatCopper.jpg/220px-NatCopper.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvZinc_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Zinc";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Zinc_fragment_sublimed_and_1cm3_cube.jpg/220px-Zinc_fragment_sublimed_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvYttrium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Yttrium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Yttrium_sublimed_dendritic_and_1cm3_cube.jpg/220px-Yttrium_sublimed_dendritic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvZirconium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Zirconium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Zirconium_crystal_bar_and_1cm3_cube.jpg/220px-Zirconium_crystal_bar_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvNiobium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Niobium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Niobium_crystals_and_1cm3_cube.jpg/220px-Niobium_crystals_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvMolybdenum_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Molybdum";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Molybdenum_crystaline_fragment_and_1cm3_cube.jpg/220px-Molybdenum_crystaline_fragment_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTechnetium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Techetium";
            img = "https://upload.wikimedia.org/wikipedia/en/thumb/8/89/Technetium.jpg/220px-Technetium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRuthenium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Ruthenium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Ruthenium_a_half_bar.jpg/220px-Ruthenium_a_half_bar.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRhodium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Rhodium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/98/Rhodium_powder_pressed_melted.jpg/220px-Rhodium_powder_pressed_melted.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPalladium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Palladium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Palladium_%2846_Pd%29.jpg/220px-Palladium_%2846_Pd%29.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSilver_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Silver";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Silver_crystal.jpg/220px-Silver_crystal.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCadmium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Cadmium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Cadmium-crystal_bar.jpg/220px-Cadmium-crystal_bar.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvHafnium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Hafnium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Hf-crystal_bar.jpg/220px-Hf-crystal_bar.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTantalum_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Tantalum";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/Tantalum_single_crystal_and_1cm3_cube.jpg/220px-Tantalum_single_crystal_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTungsten_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Tungsten";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Wolfram_evaporated_crystals_and_1cm3_cube.jpg/220px-Wolfram_evaporated_crystals_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRhenium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Rhenium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/71/Rhenium_single_crystal_bar_and_1cm3_cube.jpg/220px-Rhenium_single_crystal_bar_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvOsmium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Osmium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Osmium_crystals.jpg/220px-Osmium_crystals.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvIridium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Iridium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Iridium-2.jpg/220px-Iridium-2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPlatinum_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Platinum";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Platinum_crystals.jpg/220px-Platinum_crystals.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvGold_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Gold";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Gold-crystals.jpg/220px-Gold-crystals.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvMercury_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Mercury";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Pouring_liquid_mercury_bionerd.jpg/220px-Pouring_liquid_mercury_bionerd.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRutherfordium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Rutherfordium";
            img = "http://cf067b.medialib.glogster.com/media/62/628441032ac6b431e3f033ed796c9ec6c2ca23d1df71041c3a7555a9e4cd961f/electron-shell-104-rutherfordium.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvDubnium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Dubnium";
            img = "https://upload.wikimedia.org/wikipedia/commons/9/93/Electron_shell_105_Dubnium.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSeaborgium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Seaborgium";
            img = "https://upload.wikimedia.org/wikipedia/commons/0/08/Electron_shell_106_seaborgium.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvBohrium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Bohrium";
            img = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Electron_shell_107_Bohrium.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvHassium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Hassium";
            img = "https://upload.wikimedia.org/wikipedia/commons/3/30/Electron_shell_108_Hassium.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvCopernicium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Copernicium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Electron_shell_112_Copernicium.svg/446px-Electron_shell_112_Copernicium.svg.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }




        //###############################Post-transition Metal######################################################

        private void lsvAluminium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Aluminium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/Aluminium-4.jpg/220px-Aluminium-4.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvGallium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Gallium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Gallium_crystals.jpg/220px-Gallium_crystals.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvIndium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Indium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Indium.jpg/220px-Indium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Tin";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Sn-Alpha-Beta.jpg/220px-Sn-Alpha-Beta.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvThallium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Thallium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/Thallium_pieces_in_ampoule.jpg/220px-Thallium_pieces_in_ampoule.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvLead_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Lead";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Lead_electrolytic_and_1cm3_cube.jpg/220px-Lead_electrolytic_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvBismuth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Bismuth";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Bismuth_crystals_and_1cm3_cube.jpg/220px-Bismuth_crystals_and_1cm3_cube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPolonium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Polonium";
            img = "https://upload.wikimedia.org/wikipedia/en/thumb/6/66/Polonium.jpg/220px-Polonium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvFlerovium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Flerovium";
            img = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Electron_shell_114_Flerovium.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }


        //########################################Metalloid###################################

        private void lsvBoron_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Boron";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Boron_R105.jpg/220px-Boron_R105.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSilicon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Silicon";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/SiliconCroda.jpg/220px-SiliconCroda.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvGermanium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Germanium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Polycrystalline-germanium.jpg/220px-Polycrystalline-germanium.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvArsenic_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Arsenic";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Arsen_1a.jpg/220px-Arsen_1a.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvAntimony_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Antimony";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Antimony-4.jpg/220px-Antimony-4.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvTellurium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Tellurium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Tellurium2.jpg/220px-Tellurium2.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvAstatine_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Astatine";
            img = "https://upload.wikimedia.org/wikipedia/commons/2/29/Electron_shell_085_astatine.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }



        //####################POllyatomic non-metal####################################################

        private void lsvCarbon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Carbon";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f0/Graphite-and-diamond-with-scale.jpg/220px-Graphite-and-diamond-with-scale.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvPhosphorus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Phosphorus";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/PhosphComby.jpg/220px-PhosphComby.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSulfur_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Sulfur";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Sulfur-sample.jpg/220px-Sulfur-sample.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvSelenium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Selenium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/SeBlackRed.jpg/220px-SeBlackRed.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        //###################################Diatomic Non-Metal##########################################

        private void lsvNitrogen_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Nitrogen";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Liquidnitrogen.jpg/220px-Liquidnitrogen.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvOxygen_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Oxygen";
            img = "https://upload.wikimedia.org/wikipedia/commons/0/09/Electron_shell_008_Oxygen.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvFluorine_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Fluorine";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Liquid_fluorine_tighter_crop.jpg/220px-Liquid_fluorine_tighter_crop.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvChlorine_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Chlorine";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f4/Chlorine_ampoule.jpg/220px-Chlorine_ampoule.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvBromine_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Bromine";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Bromine_25ml_%28transparent%29.png/149px-Bromine_25ml_%28transparent%29.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvIodine_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Iodine";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Sample_of_iodine.jpg/220px-Sample_of_iodine.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }



        //#############################NOBLE GAS##########################################
        private void lsvHelium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Helium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Helium_discharge_tube.jpg/220px-Helium_discharge_tube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvNeon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Neon";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Neon_discharge_tube.jpg/220px-Neon_discharge_tube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvArgon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Argon";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Argon_discharge_tube.jpg/220px-Argon_discharge_tube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvKrypton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Krypton";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/50/Krypton_discharge_tube.jpg/220px-Krypton_discharge_tube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvXenon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Xenon";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Xenon_discharge_tube.jpg/220px-Xenon_discharge_tube.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRadon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Radon";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Electron_shell_086_Radon.svg/220px-Electron_shell_086_Radon.svg.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }
        //##################UNKNOWN PROPERTIES########################################################
        
        private void lsvMeitnerium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Meitnerium";
            img = "http://creationwiki.org/pool/images/thumb/a/a2/Electron_shell_meitnerium.png/150px-Electron_shell_meitnerium.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvDarmstadium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Darmstadium";
            img = "https://upload.wikimedia.org/wikipedia/commons/f/f6/Electron_shell_110_Darmstadtium_-_no_label.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvRoentgenium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Roentgenium";
            img = "https://upload.wikimedia.org/wikipedia/commons/f/fe/Electron_shell_111_Roentgenium.svg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvUnuntrium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Ununtrium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Electron_shell_113_Ununtrium.svg/2000px-Electron_shell_113_Ununtrium.svg.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvUnunpentium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Ununpentium";
            img = "http://www.newyorker.com/wp-content/uploads/2013/08/element-115-290_.jpg";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvLivermorium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Livermorium";
            img = "http://periodieksysteem.com/files/2013-06/500px-Electron_shell_116_Livermorium.svg.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvUnunseptium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Ununseptium";
            img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/Electron_shell_117_Ununseptium.svg/2000px-Electron_shell_117_Ununseptium.svg.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }

        private void lsvUnunoctium_Tapped(object sender, TappedRoutedEventArgs e)
        {
            url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&titles=Ununoctium";
            img = "https://upload.wikimedia.org/wikipedia/commons/b/b6/Electron_shell_118_ununoctium.png";
            Frame.Navigate(typeof(Chemical_Pages.ResultsPage));
        }


        //public void addToList()
        //{
        //    listView.Items.Add("test");
        //}

        //private void ListViewItem_Tapped_Carbon(object sender, TappedRoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(Chemical_Pages.CarbonPage));
        //}


    }
}
