using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DBUploader.Domain;

namespace DBUploader.Repository
{
    class PpidRepository
    {
        MySqlConnection conn;

        public ArrayList FindAllPpid()
        {
            ArrayList Ppids = new ArrayList();

            conn = new DBConnectorFactory().getConnection();
            string query = "SELECT * FROM recipe.ppid";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                RecipePpid ppid = new RecipePpid()
                {
                    Ppid = rdr["ppid"].ToString(),
                    Device = rdr["Device"].ToString()
                };
                Ppids.Add(ppid);
            }
            rdr.Close();
            conn.Close();
            return Ppids;
        }
    }
}
