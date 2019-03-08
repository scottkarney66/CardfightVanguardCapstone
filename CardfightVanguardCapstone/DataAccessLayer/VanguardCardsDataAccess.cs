

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataAccessLayer.DataClasses;

    class VanguardCardsDataAccess
    {
        public static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public List<VanguardCardsDO> GetVanguardCardsAll(int CardID)
        {
            List<VanguardCardsDO> ListOfCards = new List<VanguardCardsDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_GET_Vanguard_Card", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmCardID", CardID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VanguardCardsDO Card = new VanguardCardsDO();
                                Card.CardID = (int)reader["CardID"];
                                Card.CardName = (string)reader["CardName"];
                                Card.CardEffect = (string)reader["CardEffect"];
                                Card.FlavorText = (string)reader["FlavorText"];
                                Card.Clan = (string)reader["Clan"];
                                Card.Power = (string)reader["Power"];
                                Card.Race = (string)reader["Race"];
                                Card.Grade = (string)reader["Grade"];
                                Card.Shield = (string)reader["Shield"];
                                Card.Critical = (string)reader["Critical"];
                                Card.Trigger = (string)reader["Trigger"];
                                Card.Skill = (string)reader["Skill"];
                                Card.CardType = (string)reader["CardType"];
                                Card.Nation = (string)reader["Nation"];
                                Card.FK_DeckID = (int)reader["FK_DeckID"];

                                ListOfCards.Add(Card);
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {

                throw error;
            }

            return ListOfCards;
        }
        public void DeleteVanguardCards(int CardID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_Delete_Vanguard_Cards", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmCardID", CardID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {

                throw error;
            }
        }
        public bool InsertVanguardCards(VanguardCardsDO Cards)
        {
            bool _IsSucceeded = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_Insert_Vanguard_Cards", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmCardID", Cards.CardID);
                        command.Parameters.AddWithValue("@parmCardName", Cards.CardName);
                        command.Parameters.AddWithValue("@parmCardEffect", Cards.CardEffect);
                        command.Parameters.AddWithValue("@parmFlavorText", Cards.FlavorText);
                        command.Parameters.AddWithValue("@parmClan", Cards.Clan);
                        command.Parameters.AddWithValue("@parmPower", Cards.Power);
                        command.Parameters.AddWithValue("@parmRace", Cards.Race);
                        command.Parameters.AddWithValue("@parmGrade", Cards.Grade);
                        command.Parameters.AddWithValue("@parmShield", Cards.Shield);
                        command.Parameters.AddWithValue("@parmCritical", Cards.Critical);
                        command.Parameters.AddWithValue("@parmTrigger", Cards.Trigger);
                        command.Parameters.AddWithValue("@parmSkill", Cards.Skill);
                        command.Parameters.AddWithValue("@parmCardType", Cards.CardType);
                        command.Parameters.AddWithValue("@parmNation", Cards.Nation);

                        connection.Open();
                        command.ExecuteNonQuery();
                        _IsSucceeded = true;
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
        public bool UpdateVanguardCards(VanguardCardsDO Cards)
        {
            bool _IsSucceeded = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_Update_Vanguard_Cards", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmCardID", Cards.CardID);
                        command.Parameters.AddWithValue("@parmCardName", Cards.CardName);
                        command.Parameters.AddWithValue("@parmCardEffect", Cards.CardEffect);
                        command.Parameters.AddWithValue("@parmFlavorText", Cards.FlavorText);
                        command.Parameters.AddWithValue("@parmClan", Cards.Clan);
                        command.Parameters.AddWithValue("@parmPower", Cards.Power);
                        command.Parameters.AddWithValue("@parmRace", Cards.Race);
                        command.Parameters.AddWithValue("@parmGrade", Cards.Grade);
                        command.Parameters.AddWithValue("@parmShield", Cards.Shield);
                        command.Parameters.AddWithValue("@parmCritical", Cards.Critical);
                        command.Parameters.AddWithValue("@parmTrigger", Cards.Trigger);
                        command.Parameters.AddWithValue("@parmSkill", Cards.Skill);
                        command.Parameters.AddWithValue("@parmCardType", Cards.CardType);
                        command.Parameters.AddWithValue("@parmNation", Cards.Nation);

                        connection.Open();
                        command.ExecuteNonQuery();
                        _IsSucceeded = true;
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
