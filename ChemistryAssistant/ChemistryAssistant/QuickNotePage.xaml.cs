using ChemistryAssistant.Model;
using ChemistryAssistant.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChemistryAssistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuickNotePage : Page
    {
        public QuickNotePage()
        {
            this.InitializeComponent();
        }
        private void InsertNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            tbNote.Visibility = Visibility.Collapsed;
            // Try the the View Model insertion and check externally for result
            App.NOTE_VIEW_MODEL.InsertNotes(NewNoteTxtBox.Text);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Todos.ItemsSource = App.NOTE_VIEW_MODEL.GetNotes();
        }

        private void IdTextBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                string MyConnection2 = "Database=ChemDB;Data Source=eu-cdbr-azure-west-d.cloudapp.net;User Id=b1300e7178d3cc;Password=8b9c2183;SslMode=None";
                string Query = "delete from note where idNote='" + this.IdTextBox.Text + "';";

                MySqlConnection conn = new MySqlConnection(MyConnection2);
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                MySqlDataReader myReader;

                conn.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())

                {

                }
                conn.Close();
                try
                {
                    using (MySqlConnection connection = new MySqlConnection("Database=ChemDB;Data Source=eu-cdbr-azure-west-d.cloudapp.net;User Id=b1300e7178d3cc;Password=8b9c2183;SslMode=None"))
                    {
                        NoteViewModel._noteViewModel._allNotes.Clear();
                        connection.Open();
                        MySqlCommand getCommand = connection.CreateCommand();
                        getCommand.CommandText = "SELECT * FROM note";
                        using (MySqlDataReader reader = getCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NoteViewModel._noteViewModel._allNotes.Add(new Note(reader.GetString("idNote") + "         " + reader.GetString("quickNote")));
                            }
                        }
                    }
                }
                catch (MySqlException)
                {
                    // Handle it 
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
