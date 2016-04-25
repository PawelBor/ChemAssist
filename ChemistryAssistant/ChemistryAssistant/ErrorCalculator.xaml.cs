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
    public sealed partial class ErrorCalculator : Page
    {
        // Instance Variables required to Setup a path and a new sqlite Database connection
        private string path;
        public SQLite.Net.SQLiteConnection conn;



        //constructor DB
        //initlialize path variable
        //create new database
        //assign new connection to sqlite db
        //create tables based on /ERRORITEM/ class
        //close db connection
        public ErrorCalculator()
        {
            this.InitializeComponent();

            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.calculateErrorSqlite");
            dbConnection();
            conn.CreateTable<ErrorItem>();
            conn.CreateTable<RelativeErrorItem>();
            conn.CreateTable<PercentErrorItem>();
            closeDBconnection();
        }

        private async void btnCalculateError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Convert.ToDecimal(massGrams.Text.ToString());
            try
            {
                decimal experimentalValue;
                decimal knownValue;

                decimal errorValueResult;

                experimentalValue = Convert.ToDecimal(expValueInput.Text.ToString());
                knownValue = Convert.ToDecimal(knownValueInput.Text.ToString());

                errorValueResult = experimentalValue - knownValue;

                errorResult.Text = "Error: " + errorValueResult.ToString("0.000");
            }
            catch
            {
                MessageDialog clearDialog = new MessageDialog("Input must be NUMERICAL.");
                await clearDialog.ShowAsync();
            }
        }

        private async void btnRelativeCalculateError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                decimal errorValue;
                decimal relativeKnownValue;
                decimal relativeErrorValue;

                errorValue = Convert.ToDecimal(relativeErrorValueInput.Text.ToString());
                relativeKnownValue = Convert.ToDecimal(relativeKnownValueInput.Text.ToString());

                relativeErrorValue = errorValue / relativeKnownValue;

                relativeErrorResult.Text = "Rel. Error: " + relativeErrorValue.ToString("0.00");
            }
            catch
            {
                MessageDialog clearDialog = new MessageDialog("Input must be NUMERICAL.");
                await clearDialog.ShowAsync();
            }
        }

        private async void btnPercentError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {


                decimal percentRelVal;
                decimal percentErrorResult;

                percentRelVal = Convert.ToDecimal(percentRelativeErrorValueInput.Text.ToString());

                percentErrorResult = percentRelVal * 100;

                percentErrorResultValue.Text = "%Error: " + percentErrorResult.ToString("0.00") + "%";
            }
            catch
            {
                MessageDialog clearDialog = new MessageDialog("Input must be NUMERICAL.");
                await clearDialog.ShowAsync();
            }

        }



        /*Error DB*/
        //ADD ERROR
        //create SQLite DB connection
        //create variable "addError" that holds SQLite insert statement
        //set each instance variable in the ErrorItem class with values from each TextBox
        //Call Show_tapped func to asynchronously update page
        //close db conn
        //clear textboxes after adding
        private async void AddError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dbConnection();

            try
            {
                var addItem = conn.Insert(new ErrorItem()
                {
                    //resultCalc = Convert.ToDecimal(resultTxt.Text.ToString())
                    experimentalValue = Convert.ToDecimal(expValueInput.Text.ToString()),
                    knownValue = Convert.ToDecimal(knownValueInput.Text.ToString()),

                    errorValueResult = errorResult.Text
                    //resultCalc = Convert.ToDecimal(resultTxt.Text)
                });
            }
            catch
            {
                MessageDialog message = new MessageDialog("Nothing to Add.");
                await message.ShowAsync();
            }

            ShowAllError_Tapped(sender, e);
            closeDBconnection();
            //clearTextBoxes();
        }

        //SHOW/RETRIEVE ERROR
        //connect to DB
        //create a List of items and populate it with values from ErrorItem Table
        //display all Exp Value, Known value + result) in ListBox
        //close db connection
        private void ShowAllError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                List<string> itemsError = new List<string>();
                var listItems = conn.Table<ErrorItem>();
                string resultError = string.Empty;


                foreach (var itemErr in listItems)
                {
                    resultError = string.Format("Experimental Value: {0}     Known Value: {1}     {2}", itemErr.experimentalValue, itemErr.knownValue, itemErr.errorValueResult);
                    itemsError.Add(resultError);

                }

                if (itemsError.Count == 0)
                {

                    selListBoxValError.Text = "Your List is Empty!";

                }
                else if (itemsError.Count > 0)
                {
                    selListBoxValError.Text = "";

                }
                retrieveDataError.DataContext = itemsError;

                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DELETE ALL ERROR
        //connect to db
        //populate ListItems with values from ErrorItem table
        //when clicked and highlighted the ListBox control
        //remove all items
        //notify items were removed
        //call show_tapped to update page (asynchronous)
        //close db conn
        private async void DeleteAllError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                var listItems = conn.Table<ErrorItem>();
                List<string> itemsError = new List<string>();

                foreach (var itemErr in listItems)
                {
                    conn.Delete<ErrorItem>(itemErr.id);
                }
                ShowAllError_Tapped(sender, e);
                closeDBconnection();

                MessageDialog message = new MessageDialog("All Items Removed");
                await message.ShowAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }




        /*Relative DB*/
        //ADD RELATIVE
        //create SQLite DB connection
        //create variable "addItem" that holds SQLite insert statement
        //set each instance variable in the ErrorItem class with values from each TextBox
        //Call Show_tapped func to asynchronously update page
        //close db conn
        //clear textboxes after adding
        private async void AddRelative_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dbConnection();

            try
            {
                var addItem = conn.Insert(new RelativeErrorItem()
                {
                    errorValue = Convert.ToDecimal(relativeErrorValueInput.Text.ToString()),
                    relativeKnownValue = Convert.ToDecimal(relativeKnownValueInput.Text.ToString()),

                    relativeErrorValue = relativeErrorResult.Text
                });

                ShowAllRelative_Tapped(sender, e);
                closeDBconnection();
                //clearTextBoxes();
            }
            catch
            {
                MessageDialog message = new MessageDialog("Nothing to Add.");
                await message.ShowAsync();
            }
        }

        //SHOW/RETRIEVE RELATIVE
        //connect to DB
        //create a List of items and populate it with values from ErrorItem Table
        //display all (Error, Known Value, Relative error result) in ListBox
        //close db connection
        private void ShowAllRelative_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                List<string> itemsRelative = new List<string>();
                var listItems = conn.Table<RelativeErrorItem>();
                string resultRelative = string.Empty;


                foreach (var itemRel in listItems)
                {
                    resultRelative = string.Format("Error: {0}     Known Value: {1}     {2}", itemRel.errorValue, itemRel.relativeKnownValue, itemRel.relativeErrorValue);
                    itemsRelative.Add(resultRelative);

                }

                if (itemsRelative.Count == 0)
                {

                    selListBoxValRelative.Text = "Your List is Empty!";

                }
                else if (itemsRelative.Count > 0)
                {
                    selListBoxValRelative.Text = "";
                }
                retrieveDataRelative.DataContext = itemsRelative;

                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DELETE ALL RELATIVE
        //connect to db
        //populate ListItems with values from RelativeItem table
        //when clicked and highlighted the ListBox control
        //remove all items
        //notify items were removed
        //call show_tapped to update page (asynchronous)
        //close db conn
        private async void DeleteAllReltive_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                var listItems = conn.Table<RelativeErrorItem>();
                List<string> itemsRelative = new List<string>();

                foreach (var itemRel in listItems)
                {
                    conn.Delete<RelativeErrorItem>(itemRel.id);
                }
                ShowAllRelative_Tapped(sender, e);
                closeDBconnection();

                MessageDialog message = new MessageDialog("All Items Removed");
                await message.ShowAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*Percent DB*/
        private async void AddPercent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dbConnection();

            try
            {
                var addItem = conn.Insert(new PercentErrorItem()
                {
                    percentRelVal = Convert.ToDecimal(percentRelativeErrorValueInput.Text.ToString()),

                    percentErrorResult = percentErrorResultValue.Text
                });

                ShowAllPercent_Tapped(sender, e);
                closeDBconnection();
                //clearTextBoxes();
            }
            catch
            {
                MessageDialog message = new MessageDialog("Nothing to Add.");
                await message.ShowAsync();
            }
        }

        private void ShowAllPercent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                List<string> itemsPercent = new List<string>();
                var listItems = conn.Table<PercentErrorItem>();
                string resultPercent = string.Empty;


                foreach (var itemPer in listItems)
                {
                    resultPercent = string.Format("Relative Error {0}     {1}", itemPer.percentRelVal, itemPer.percentErrorResult);
                    itemsPercent.Add(resultPercent);

                }

                if (itemsPercent.Count == 0)
                {

                    selListBoxValPercentage.Text = "Your List is Empty!";

                }
                else if (itemsPercent.Count > 0)
                {
                    selListBoxValPercentage.Text = "";
                }
                retrieveDataPercentage.DataContext = itemsPercent;

                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void DeleteAllPercent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                var listItems = conn.Table<PercentErrorItem>();
                List<string> itemsPercent = new List<string>();

                foreach (var itemPer in listItems)
                {
                    conn.Delete<PercentErrorItem>(itemPer.id);
                }
                ShowAllPercent_Tapped(sender, e);
                closeDBconnection();

                MessageDialog message = new MessageDialog("All Items Removed");
                await message.ShowAsync();
            }
            catch (Exception)
            {
                throw;
            }
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


        //sharing results to external applications.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //empty

            base.OnNavigatedTo(e);
        }


        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{

        //    Windows.ApplicationModel.DataTransfer.DataTransferManager.GetForCurrentView().DataRequested -= MainPage_DataRequested;
        //    base.OnNavigatedFrom(e);
        //}

        private void Error_DataRequested(Windows.ApplicationModel.DataTransfer.DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            if (!string.IsNullOrEmpty(expValueInput.Text + knownValueInput.Text + errorResult.Text))
            {


                args.Request.Data.SetText("Experimental Value: " + expValueInput.Text + "   Known Value: " + knownValueInput.Text + "   " + errorResult.Text);
                args.Request.Data.Properties.Title = Windows.ApplicationModel.Package.Current.DisplayName;
            }
            else
            {
                args.Request.FailWithDisplayText("Nothing to share");
            }
        }

        private void Relative_DataRequested(Windows.ApplicationModel.DataTransfer.DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            if (!string.IsNullOrEmpty(relativeErrorValueInput.Text + relativeKnownValueInput.Text + relativeErrorResult.Text))
            {


                args.Request.Data.SetText("Error: " + relativeErrorValueInput.Text + "   Known Value: " + relativeKnownValueInput.Text + "   " + relativeErrorResult.Text);
                args.Request.Data.Properties.Title = Windows.ApplicationModel.Package.Current.DisplayName;
            }
            else
            {
                args.Request.FailWithDisplayText("Nothing to share");
            }
        }

        private void Percent_DataRequested(Windows.ApplicationModel.DataTransfer.DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            if (!string.IsNullOrEmpty(percentRelativeErrorValueInput.Text + percentErrorResultValue.Text))
            {


                args.Request.Data.SetText("Relative Error: " + percentRelativeErrorValueInput.Text + percentErrorResultValue.Text);
                args.Request.Data.Properties.Title = Windows.ApplicationModel.Package.Current.DisplayName;
            }
            else
            {
                args.Request.FailWithDisplayText("Nothing to share");
            }
        }


        private void ShareError_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.GetForCurrentView().DataRequested += Error_DataRequested;

            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }



        private void ShareRelative_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.GetForCurrentView().DataRequested += Relative_DataRequested;

            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }

        private void SharePercent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.GetForCurrentView().DataRequested += Percent_DataRequested;

            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }



    }
}
