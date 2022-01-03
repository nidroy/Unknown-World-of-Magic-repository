using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Unknown_World_of_Magic_server
{
    public class Database
    {
        // БД SQL Server
        //public static string connectionString = "Data Source=MYLAPTOP;Initial Catalog=Unknown World of Magic database;Integrated Security=True";
        // Локальная БД
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Unknown World of Magic\\Database\\Unknown World of Magic database.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection = new SqlConnection(connectionString);

        public List<string> GetPlayers()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Name, ClassName, Level, Gold FROM Character JOIN Player ON Character.ID = Player.CharacterID JOIN Class ON Player.ClassID = Class.ID;";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(String.Format("{0}_{1}_{2}_{3}", reader[0], reader[1], reader[2], reader[3])); // reader столбцы, List строки
                }
                connection.Close();
            }
            return result;
        }

        #region сохранить игру

        public void SaveGame(string playerName)
        {
            UpdateCharacter(playerName);
            UpdatePlayer(playerName);
            UpdateEnemy(playerName);
        }

        private void UpdateCharacter(string playerName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("UPDATE Character SET HealthPoints = '{0}', ExperiencePoints = '{1}', Level = '{2}', Gold = '{3}', Damage = '{4}', Miss = '{5}', LocationID = '{6}' WHERE Name = '{7}';", Player.playerHealthPoints, Player.playerExperiencePoints, Player.playerLevel, Player.playerGold, Player.playerDamage, Player.playerMiss, Location.locationNumber, playerName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        private void UpdatePlayer(string playerName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("UPDATE Player SET ActionPoints = '{0}', SkillPoints = '{1}', Strength = {2}, Agility = '{3}', Intelligence = '{4}' WHERE Player.CharacterID = (SELECT Character.ID FROM Character WHERE Name = '{5}');", Player.playerActionPoints, Player.playerSkillPoints, Characteristics.strength, Characteristics.agility, Characteristics.intelligence, playerName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        private void UpdateEnemy(string playerName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("UPDATE EnemyForPlayer SET EnemyID = (SELECT Enemy.ID FROM Enemy JOIN Character ON Enemy.CharacterID = Character.ID WHERE Name = '{0}') WHERE PlayerID = (SELECT Player.ID FROM Player JOIN Character ON Player.CharacterID = Character.ID WHERE Name = '{1}');", Enemy.enemyName, playerName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        #endregion

        #region получить атрибуты

        public string GetAttributes(string playerName)
        {
            return String.Format("{0}_{1}_{2}", GetPlayerAttributes(playerName), GetEnemyAttributes(playerName), GetLocationAttributes(playerName));
        }

        private string GetPlayerAttributes(string playerName)
        {
            string playerAttributes = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT Name, ClassName, HealthPoints, ActionPoints, ExperiencePoints, SkillPoints, Level, Gold, Damage, Miss, Strength, Agility, Intelligence FROM Character JOIN Player ON Character.ID = Player.CharacterID JOIN Class ON Player.ClassID = Class.ID WHERE Character.Name = '{0}';", playerName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    playerAttributes = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}_{9}_{10}_{11}_{12}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10], reader[11], reader[12]);
                }
                connection.Close();
            }

            string[] attribute = playerAttributes.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            SetPlayerAttributes(attribute);

            return playerAttributes;
        }

        private string GetEnemyAttributes(string playerName)
        {
            string enemyAttributes = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT Name, HealthPoints, ExperiencePoints, Level, Gold, Damage, Miss FROM Character JOIN Enemy ON Character.ID = Enemy.CharacterID WHERE Enemy.ID = (SELECT EnemyID FROM EnemyForPlayer JOIN Player ON EnemyForPlayer.PlayerID = Player.ID JOIN Character ON Player.CharacterID = Character.ID WHERE Name = '{0}');", playerName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    enemyAttributes = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                }
                connection.Close();
            }

            string[] attribute = enemyAttributes.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            SetEnemyAttributes(attribute);

            return enemyAttributes;
        }

        private string GetLocationAttributes(string playerName)
        {
            string locationAttributes = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT Location.ID, Location.Name, Location.Description FROM Location JOIN Character ON Location.ID = Character.LocationID WHERE Character.Name = '{0}';", playerName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    locationAttributes = String.Format("{0}_{1}_{2}", reader[0], reader[1], reader[2]);
                }
                connection.Close();
            }

            string[] attribute = locationAttributes.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            SetLocationAttributes(attribute);

            return locationAttributes;
        }

        #region установить атрибуты

        private void SetPlayerAttributes(string[] attribute)
        {
            Player.playerName = attribute[0];
            Player.playerClass = attribute[1];
            Player.playerHealthPoints = int.Parse(attribute[2]);
            Player.playerActionPoints = int.Parse(attribute[3]);
            Player.playerExperiencePoints = int.Parse(attribute[4]);
            Player.playerSkillPoints = int.Parse(attribute[5]);
            Player.playerLevel = int.Parse(attribute[6]);
            Player.playerGold = int.Parse(attribute[7]);
            Player.playerDamage = int.Parse(attribute[8]);
            Player.playerMiss = int.Parse(attribute[9]);
            Characteristics.strength = int.Parse(attribute[10]);
            Characteristics.agility = int.Parse(attribute[11]);
            Characteristics.intelligence = int.Parse(attribute[12]);
        }

        private void SetEnemyAttributes(string[] attribute)
        {
            Enemy.enemyName = attribute[0];
            Enemy.enemyHealthPoints = int.Parse(attribute[1]);
            Enemy.enemyExperiencePoints = int.Parse(attribute[2]);
            Enemy.enemyLevel = int.Parse(attribute[3]);
            Enemy.enemyGold = int.Parse(attribute[4]);
            Enemy.enemyDamage = int.Parse(attribute[5]);
            Enemy.enemyMiss = int.Parse(attribute[6]);
        }

        private void SetLocationAttributes(string[] attribute)
        {
            Location.locationNumber = int.Parse(attribute[0]);
            Location.locationName = attribute[1];
            Location.locationDescription = attribute[2];
        }

        #endregion

        #endregion

        #region создать игрока

        public string CreatePlayer()
        {
            bool isPlayerExists = false;
            List<string> playerName = new List<string>();
            playerName = GetPlayerName();
            for(int i = 0; i < playerName.Count; i++)
            {
                if(Player.playerName == playerName[i])
                {
                    isPlayerExists = true;
                }
            }

            if(isPlayerExists)
            {
                return "PlayerExists";
            }
            else
            {
                InsertCharacter();
                InsertPlayer();
                InsertEnemy();
            }
            return "THE PLAYER IS CREATED";
        }

        private List<string> GetPlayerName()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Name FROM Character JOIN Player ON Character.ID = Player.CharacterID";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
                connection.Close();
            }
            return result;
        }

        private void InsertCharacter()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO Character VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", Player.playerName, Player.playerHealthPoints, Player.playerExperiencePoints, Player.playerLevel, Player.playerGold, Player.playerDamage, Player.playerMiss, Location.locationNumber);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        private void InsertPlayer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO Player VALUES ((SELECT ID FROM Character WHERE Name = '{0}'), (SELECT ID FROM Class WHERE ClassName = '{1}'), '{2}', '{3}', '{4}', '{5}', '{6}');", Player.playerName, Player.playerClass, Player.playerActionPoints, Player.playerSkillPoints, Characteristics.strength, Characteristics.agility, Characteristics.intelligence);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        private void InsertEnemy()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO EnemyForPlayer VALUES ((SELECT Player.ID FROM Player JOIN Character ON Player.CharacterID = Character.ID WHERE Name = '{0}'), (SELECT Enemy.ID FROM Enemy JOIN Character ON Enemy.CharacterID = Character.ID WHERE Name = '{1}'));", Player.playerName, Enemy.enemyName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        #endregion
    }
}
