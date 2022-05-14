using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Domain;
using MySql.Data.MySqlClient;

namespace DBUploader.Repository
{
    class DBUploadRepository
    {        
        MySqlConnection conn;

        public DBUploadRepository()
        {
            conn = new DBConnectorFactory().getConnection();
        }

        public void DBParamUpload(RecipeParam param)
        {
            string queryForm =
                @"INSERT INTO recipe.spec
                    (cluster_recipe,
                    frontside_recipe,
                    inspection_dies,
                    inspection_columns,
                    inspection_rows)
                VALUES(
                    '{0}', '{1}', '{2}', '{3}', '{4}')
                ON
                    duplicate
                KEY UPDATE
                    modify_date = CURDATE();";
            string query = string.Format(queryForm,
                param.ClusterRecipe,
                param.FrontsideRecipe,
                int.Parse(param.InspectionDies),
                int.Parse(param.InspectionColumns),
                int.Parse(param.InspectionRows));
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
