using ChemistryAssistant.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant.ViewModel
{
    public class NoteViewModel
    {
        public static NoteViewModel _noteViewModel = new NoteViewModel();
        public ObservableCollection<Note> _allNotes = new ObservableCollection<Note>();

        public ObservableCollection<Note> AllNotes
        {
            get
            {
                return _noteViewModel._allNotes;
            }
        }

        public IEnumerable<Note> GetNotes()
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection("Database=ChemDB;Data Source=eu-cdbr-azure-west-d.cloudapp.net;User Id=b1300e7178d3cc;Password=8b9c2183;SslMode=None"))
                {
                    connection.Open();
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT * FROM note";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _noteViewModel._allNotes.Add(new Note(reader.GetString("idNote") + "         " + reader.GetString("quickNote")));
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                // Handle it :)
            }
            return _noteViewModel.AllNotes;
        }

        public bool InsertNotes(string notewht)
        {
            Note newNote = new Note(notewht);
            // Insert to the collection and update DB
            try
            {
                using (MySqlConnection connection = new MySqlConnection("Database=ChemDB;Data Source=eu-cdbr-azure-west-d.cloudapp.net;User Id=b1300e7178d3cc;Password=8b9c2183;SslMode=None"))
                {
                    connection.Open();
                    MySqlCommand insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT INTO note(quickNote)VALUES(@quickNote)";
                    insertCommand.Parameters.AddWithValue("@quickNote", newNote.quickNote);
                    insertCommand.ExecuteNonQuery();
                    _noteViewModel._allNotes.Add(newNote);

                    _noteViewModel._allNotes.Clear();

                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT * FROM note";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _noteViewModel._allNotes.Add(new Note(reader.GetString("idNote") + "         " + reader.GetString("quickNote")));
                        }
                    }

                    return true;


                }
            }
            catch (MySqlException)
            {
                // Don't forget to handle it
                return false;
            }



        }



        public NoteViewModel()
        {
            // Establish the connection

        }
    }
}
