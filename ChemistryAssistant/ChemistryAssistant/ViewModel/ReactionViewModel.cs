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
    public class ReactionViewModel
    {
        private static ReactionViewModel _reactionViewModel = new ReactionViewModel();
        private ObservableCollection<Reaction> _allReactions = new ObservableCollection<Reaction>();

        public ObservableCollection<Reaction> AllReactions
        {
            get
            {
                return _reactionViewModel._allReactions;
            }
        }
        /*-Establish connection
          -Open It
          -Initialize command(Query)
          -Execute command
          -Read incoming values and initialize new Todo object then add it to observable collection for data binding*/
        public IEnumerable<Reaction> GetReactions()
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection("Database=ChemDB;Data Source=eu-cdbr-azure-west-d.cloudapp.net;User Id=b1300e7178d3cc;Password=8b9c2183;SslMode=None"))
                {
                    connection.Open();
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT * FROM reactions";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read() && !MenuPage.chemPageInitialized )
                        {

                            //populating OC with idreaction and reactionDesc
                           
                            _reactionViewModel._allReactions.Add(new Reaction(reader.GetString("reactionTitle") + "            " + reader.GetString("reactionDesc")));
                        }
                        MenuPage.chemPageInitialized = true;
                    }
                }
            }
            catch (MySqlException)
            {
                // Handle it :)

            }
            return _reactionViewModel.AllReactions;
        }

       


        public ReactionViewModel()
        {
            // Establish the connection

        }
    }
}
