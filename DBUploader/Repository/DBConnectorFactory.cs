using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DBUploader.Repository
{
    class DBConnectorFactory
    {
        public MySqlConnection getConnection()
        {

            return new MySqlConnection(dbArg());
        }

        public String dbArg()
        {
            using (StreamReader file = File.OpenText("dbConfig.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject json = (JObject)JToken.ReadFrom(reader);
                StringBuilder _strArg = new StringBuilder();

                _strArg.Append("Server=");
                _strArg.Append(json["ip"].ToString());
                _strArg.Append(";Port=");
                _strArg.Append(json["port"].ToString());
                _strArg.Append(";Database = ");
                _strArg.Append(json["database"].ToString());          // 데이터베이스
                _strArg.Append(";Uid = ");
                _strArg.Append(json["id"].ToString());                     // ID
                _strArg.Append(";Pwd = ");
                _strArg.Append(json["pw"].ToString());                 // PWD
                _strArg.Append(";");
                return _strArg.ToString();
            }
        }
    }
}