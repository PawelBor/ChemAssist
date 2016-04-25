
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class CalculatorPage : Page
    {

        // Instance Variables required to Setup a path and a new sqlite Database connection
        private string path;
        public SQLite.Net.SQLiteConnection conn;


        //constructor
        //initlialize path variable
        //create new database
        //assign new connection to sqlite db
        //create table based on /ITEM/ class
        //close db connection

        public CalculatorPage()
        {
            this.InitializeComponent();
            this.meta();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.calculateMolaritySqlite");
            dbConnection();
            conn.CreateTable<Item>();
            closeDBconnection();
        }

        private void btnCalculate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            decimal moles;
            decimal mass;
            decimal mr; //molar mass of atoms

            mass = Convert.ToDecimal(massGrams.Text.ToString());

            mr = Convert.ToDecimal(molarMass.Text.ToString());

            moles = mass / mr;

            molesResult.Text = "Moles: " + moles.ToString("0.00000");

        }






        //second Calculation

        //txtBox descriptions
        private void meta()
        {
            string formula = "M1 V1 = M2 V2";
            string header = "DILUTION Calculator";
            string description = "*all input should be in Litre format (1.25mL = 0.00125)";
            string molarDesc = "Molar Mass / Mass";
            formulaMVMV.Text = "Dilution Formula " + formula;
            headerMVMV.Text = header;
            descriptionMVMV.Text = description;
            //molarDescription.Text = molarDesc;
        }



        private async void calcResult_Tapped(object sender, TappedRoutedEventArgs e)
        {
            decimal m1 = 0;
            decimal m2 = 0;
            decimal v1 = 0;
            decimal v2 = 0;

            int i = 0;


            // catches alphabetical input from user and displays error message
            try
            {
                //getting info needed for calc from textboxes
                if (m1Txt.Text.ToString() != "")
                {
                    m1 = Convert.ToDecimal(m1Txt.Text.ToString());
                    i++;
                }

                if (v1Txt.Text.ToString() != "")
                {
                    v1 = Convert.ToDecimal(v1Txt.Text.ToString());
                    i++;
                }

                if (m2Txt.Text.ToString() != "")
                {
                    m2 = Convert.ToDecimal(m2Txt.Text.ToString());
                    i++;
                }

                if (v2Txt.Text.ToString() != "")
                {
                    v2 = Convert.ToDecimal(v2Txt.Text.ToString());
                    i++;
                }
            }
            catch
            {
                MessageDialog clearDialog = new MessageDialog("Input must be NUMERICAL.");
                await clearDialog.ShowAsync();
            }

            // error handling - user must enter 3 values, otherwise message will be displayed.
            if (i == 3)
            {
                //calculation based on what is not known
                if (m2 == 0)
                {
                    m2 = (m1 * v1) / v2;

                    resultTxt.Text = "Molarity needed(mol): " + m2;
                }
                else if (v2 == 0)
                {
                    v2 = (m1 * v1) / m2;

                    resultTxt.Text = "Volume needed(mL): " + v2;
                }
                else if (v1 == 0)
                {
                    v1 = (m2 * v2) / m1;

                    resultTxt.Text = "Volume needed(mL): " + v1;
                }
                else if (m1 == 0)
                {
                    m1 = (m2 * v2) / v1;

                    resultTxt.Text = "Molarity needed(mol): " + m1;
                }
            }
            else
            {
                MessageDialog clearDialog = new MessageDialog("Minimum/Maximum input must be 3 Values.");
                await clearDialog.ShowAsync();

            }

        }//end of calcResult_tapped


        private async void Add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //if one of the textboxes input was null it will be 0(crash measure)
            try
            {
                if (m1Txt.Text == "")
                {
                    m1Txt.Text = "0";
                }
                else if (v1Txt.Text == "")
                {
                    v1Txt.Text = "0";
                }
                else if (m2Txt.Text == "")
                {
                    m2Txt.Text = "0";
                }
                else if (v2Txt.Text == "")
                {
                    v2Txt.Text = "0";
                }

                //ADD
                //create SQLite DB connection
                //create variable "addItem" that holds SQLite insert statement
                //set each instance variable in the Item class with values from each TextBox
                //Call Show_tapped func to asynchronously update page
                //close db conn
                //clear textboxes after adding

                dbConnection();

                var addItem = conn.Insert(new Item()
                {
                    //resultCalc = Convert.ToDecimal(resultTxt.Text.ToString())
                    m1 = Convert.ToDecimal(m1Txt.Text.ToString()),
                    v1 = Convert.ToDecimal(v1Txt.Text.ToString()),
                    m2 = Convert.ToDecimal(m2Txt.Text.ToString()),
                    v2 = Convert.ToDecimal(v2Txt.Text.ToString()),
                    resultCalc = resultTxt.Text
                    //resultCalc = Convert.ToDecimal(resultTxt.Text)
                });

                Show_Tapped(sender, e);
                closeDBconnection();
                clearTextBoxes();

            }
            catch (Exception)
            {
                MessageDialog message = new MessageDialog("Nothing to Add.");
                await message.ShowAsync();

            }
        }//end func


        //SHOW/RETRIEVE
        //connect to DB
        //create a List of items and populate it with values from Item Table
        //display all (M1,V1,M2,V2 + Result) in ListBox
        //close db connection
        private void Show_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                List<string> items = new List<string>();
                var listItems = conn.Table<Item>();
                string result = string.Empty;


                foreach (var item in listItems)
                {
                    result = string.Format("M1: {0}     V1: {1}     M2: {2}     V2: {3}     {4}", item.m1, item.v1, item.m2, item.v2, item.resultCalc);
                    //result = string.Format("   {0} ", item.resultCalc);
                    items.Add(result);
                    
                }

                if (items.Count == 0)
                {

                    selListBoxVal.Text = "Your List is Empty!";

                }
                else if (items.Count > 0)
                {
                    selListBoxVal.Text = "";
                }
                retrieveData.DataContext = items;

                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }

        } // End Function

        //DELETE ALL
        //connect to db
        //populate ListItems with values from Item table
        //when clicked and highlighted the ListBox control
        //remove all items
        //notify items were removed
        //call show_tapped to update page (asynchronous)
        //close db conn
        private async void DeleteAll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                var listItems = conn.Table<Item>();
                List<string> items = new List<string>();

                foreach (var item in listItems)
                {
                    conn.Delete<Item>(item.id);
                }
                Show_Tapped(sender, e);
                closeDBconnection();

                MessageDialog message = new MessageDialog("All Items Removed");
                await message.ShowAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DELETE SELECTED
        //connect to db
        //populate List with values from itemTable
        //use compareResult to store result that's checked in DB against the selected item tapped in ListBox
        //if there is a match, delete the item from db
        //call show_tapped to update the page
        //close db connection
        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                var listItems = conn.Table<Item>();
                List<string> items = new List<string>();
                foreach (var item in listItems)
                {
                    string compareResult = string.Format("M1: {0}     V1: {1}     M2: {2}     V2: {3}     {4}", item.m1, item.v1, item.m2, item.v2, item.resultCalc);
                    //string compareResult = string.Format("   {0} ", item.resultCalc);
                    if (retrieveData.SelectedValue.Equals(compareResult))
                    {
                        conn.Delete<Item>(item.id);
                    }
                }
                Show_Tapped(sender, e);
                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }
        }//end delete(all)

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //empty

            base.OnNavigatedTo(e);
        }

        private void DilutionCalc_DataRequested(Windows.ApplicationModel.DataTransfer.DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            if (!string.IsNullOrEmpty(m1Txt.Text + v1Txt.Text + m2Txt.Text + v2Txt.Text + resultTxt.Text))
            {


                args.Request.Data.SetText("M1: " + m1Txt.Text + "   V1: " + v1Txt.Text + "   M2: " + m2Txt.Text + "   V2: " + v2Txt.Text + "    " + resultTxt.Text);
                args.Request.Data.Properties.Title = Windows.ApplicationModel.Package.Current.DisplayName;
            }
            else
            {
                args.Request.FailWithDisplayText("Nothing to share");
            }
        }

        private void ShareResult_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.GetForCurrentView().DataRequested += DilutionCalc_DataRequested;

            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }

        // DB connection function that holds the initialised value of the conn variable, complete with path and connection information
        private void dbConnection()
        {
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }


        // Close / Dispose the DB connections for each operation
        private void closeDBconnection()
        {
            conn.Commit();
            conn.Dispose();
            conn.Close();
        }

        // Function to clear TextBoxes, after an item has been added
        private void clearTextBoxes()
        {
            m1Txt.Text = "";
            v1Txt.Text = "";
            m2Txt.Text = "";
            v2Txt.Text = "";
            resultTxt.Text = "";

        }

        
    }
}
