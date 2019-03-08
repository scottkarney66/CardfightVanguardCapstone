using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataClasses;

namespace DataAccessLayer
{
    class VanguardsDecksDataAccess
    {
        public static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public List<VanguardDecksDO> GetVanguardDecks(int DeckID)
        {
            List<VanguardDecksDO> ListOfDecks = new List<VanguardDecksDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_GET_Vanguard_Deck", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmDeckID", DeckID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VanguardDecksDO Decks = new VanguardDecksDO();
                                Decks.DeckID = (int)reader["DeckID"];
                                Decks.DeckName = (string)reader["DeckName"];

                                ListOfDecks.Add(Decks);
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {

                throw error;
            }
            return ListOfDecks;
        }

        public void DeleteVanguardDecks(int DeckID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_Delete_Vanguard_Deck", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmDeckID", DeckID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {

                throw error
;
            }
        }

        public bool InsertVanguardDecks(VanguardDecksDO Deck)
        {
            bool _IsSucceeded = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_Insert_Vanguard_Deck", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmDeckID", Deck.DeckID);
                        command.Parameters.AddWithValue("@parmDeckName", Deck.DeckName);
                    }
                }
            }
            catch (Exception error)
            {
                _IsSucceeded = false;
                throw error;
            }
            return _IsSucceeded;
        }

        public bool UpdateVanguardDecks(VanguardDecksDO Deck)
        {
            bool _IsSucceeded = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_Update_Vanguard_Deck", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmDeckID", Deck.DeckID);
                        command.Parameters.AddWithValue("@parmDeckName", Deck.DeckName);
                    }
                }
            }
            catch (Exception error)
            {
                _IsSucceeded = false;
                throw error;
            }
            return _IsSucceeded;
        }



    }
}
