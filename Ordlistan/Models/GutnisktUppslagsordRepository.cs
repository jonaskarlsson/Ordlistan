using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Ordlistan.Models
{
    public class GutnisktUppslagsordRepository
    {
        // Get connection string from web.config.
        private static string connectionString;

        internal List<GutnisktUppslagsord> HittaGutnisktUppslagsord(string sokord, int maxResultat)
        {

            List<GutnisktUppslagsord> gutnisktUppslagsord = new List<GutnisktUppslagsord>();
            ByggListaAvGutniskaUppslagsord(gutnisktUppslagsord);

            var result = from n in gutnisktUppslagsord
                         where n.Uppslagsord.Contains(sokord)
                         orderby n.Uppslagsord
                         select n;

            return result.Take(maxResultat).ToList();

        }

        private static void ByggListaAvGutniskaUppslagsord(List<GutnisktUppslagsord> gutnisktUppslagsord)
        {
            
            // Get connection string from web.config.
            connectionString = WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;

           
                // Create a connection object and data adapter
                MySqlConnection cnx = new MySqlConnection(connectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string sql = "SELECT  `GutnisktUppslagsord`,  `PKordlistanr` FROM `d17704`.`tbl_ordlistan`;";
                MySqlCommand cmd = new MySqlCommand(sql, cnx);

                try
                {
                    cnx.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        GutnisktUppslagsord mGutnisktUppslagsord = new GutnisktUppslagsord();
                        string mUppslagsord = "";
                        int mPKordlistanr = 0;

                        //Check for NULL-values
                        if (reader["GutnisktUppslagsord"] is DBNull)
                        {
                            mUppslagsord = "";
                        }
                        else
                        {
                            mUppslagsord = (string)reader["GutnisktUppslagsord"];
                        }

                        //Check for NULL-values
                        if (reader["PKordlistanr"] is DBNull)
                        {
                            mPKordlistanr = 0;
                        }
                        else
                        {
                            mPKordlistanr = reader.GetInt16(1);
                        }

                        mGutnisktUppslagsord.Uppslagsord = mUppslagsord;
                        mGutnisktUppslagsord.Id = mPKordlistanr;

                        gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = mGutnisktUppslagsord.Id, Uppslagsord = mGutnisktUppslagsord.Uppslagsord });

                    }
                    reader.Close();
                }
                catch (Exception ex) { }
            }
        }
    }
