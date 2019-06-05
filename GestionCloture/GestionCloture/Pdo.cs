using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GestionCloture
{
    public class Pdo
    {

        //variables
        private string host;
        private int port;
        private string dbname;
        private string username;
        private string password;
        private MySqlConnection connection;
        private string connectionString;


        //constructor
        public Pdo(string host, int port, string dbname, string username, string password)
        {
            this.setHost(host);
            this.setPort(port);
            this.setPassword(password);
            this.setUsername(username);
            this.setDbname(dbname);
            this.setConnectionString();
            this.Connection();

        }


        // Connection method
        public void Connection()
        {
            this.connection = new MySqlConnection(this.connectionString);
            this.connection.Open();
        }

        //Close connection method
        public void Close()
        {
            this.connection.Close();
        }


        //Insert method
        public void insert(string table, object[] valeurs)
        {
            try
            {
                //command line creation
                MySqlCommand cmd = this.connection.CreateCommand();
                string lesValeurs = "";
                foreach (object uneValeur in valeurs)
                {
                    lesValeurs += uneValeur + ",";
                }
                //del last comma
                lesValeurs = lesValeurs.Substring(0, lesValeurs.Length - 1);

                cmd.CommandText = "INSERT INTO " + table + " VALUES (" + lesValeurs + ");";
                cmd.ExecuteNonQuery();
            }
            catch (IOException e)
            {
                Console.Write("Error :" + e);

            }
        }

        //update method
        public void update(string table, string colonne, object newValeur, string condition)
        {
            try
            {
                //command line creation
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "UPDATE " + table + " SET " + colonne + " = " + newValeur;
                if (condition != null)
                {
                    cmd.CommandText += " WHERE " + condition;
                }
                cmd.ExecuteNonQuery();
            }
            catch (IOException e)
            {
                Console.Write("Error :" + e);

            }
        }

        //delete method
        public void delete(string table, string condition)
        {
            try
            {
                //command line creation
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "DELETE FROM " + table;
                if (condition != null)
                {
                    cmd.CommandText += " WHERE " + condition;
                }
                cmd.ExecuteNonQuery();
            }
            catch (IOException e)
            {
                Console.Write("Error :" + e);

            }
        }

        //create method
        public void create(string table, string[] colonnes, string[] typeVariable)
        {
            try
            {
                //command line creation
                MySqlCommand cmd = this.connection.CreateCommand();
                string lesColonnes = "";
                for (int i = 0; i < colonnes.Length; i++)
                {
                    lesColonnes += colonnes[i] + " " + typeVariable[i] + ",";
                }
                //del last comma
                lesColonnes = lesColonnes.Substring(0, lesColonnes.Length - 1);

                cmd.CommandText = "CREATE TABLE " + table + " ( " + lesColonnes + " );";
                cmd.ExecuteNonQuery();
            }
            catch (IOException e)
            {
                Console.Write("Error :" + e);

            }
        }

        //select method
        public object[] Select(string table, string[] colonnes, string condition)
        {
            try
            {
                //command line creation
                MySqlCommand cmd = this.connection.CreateCommand();
                string lesColonnes = "";
                if (colonnes != null)
                {
                    for (int i = 0; i <= colonnes.Length; i++)
                    {
                        lesColonnes += colonnes[i] + ",";
                    }
                    //del last comma
                    lesColonnes = lesColonnes.Substring(0, lesColonnes.Length - 1);
                    cmd.CommandText = "SELECT " + lesColonnes + " FROM " + table;
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM " + table;
                }

                if (condition != null)
                {
                    cmd.CommandText += " WHERE " + condition;
                }
                MySqlDataReader res = cmd.ExecuteReader();
              
                if (res.HasRows)
                {
                    var results = new List<string[]>();
                    while (res.Read())
                    {
                        var resultats = new string[res.FieldCount];
                        for (int i =0; i < res.FieldCount; i++)
                        {
                            resultats[i] = res.GetString(i);
                        }
                        results.Add(resultats);
                    }
                    return results.ToArray();
                } else
                {
                    return null;
                }
            }
                
            catch (IOException e)
            {
                Console.Write("Error :" + e);
                return null;

            }
        }

        //setters
        public void setConnectionString()
        {
            this.connectionString = "Server =" + this.host + "; Port =" + this.port + "; Database =" + this.dbname + "; Uid =" + this.username + "; Pwd =" + this.password + ";";
        }

        public void setHost(string host)
        {
            this.host = host;
        }
        public void setPort(int port)
        {
            this.port = port;
        }
        public void setDbname(string dbname)
        {
            this.dbname = dbname;
        }
        public void setUsername(string username)
        {
            this.username = username;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }

        //getters
        public string getHost()
        {
            return this.host;
        }
        public int getPort()
        {
            return this.port;
        }
        public string getDbname()
        {
            return this.dbname;
        }
        public string getUsername()
        {
            return this.username;
        }
        public string getPassword()
        {
            return this.password;
        }
    }


}
