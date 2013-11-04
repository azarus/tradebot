using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Helpers;
using MySql.Data.MySqlClient; 

namespace Library.Helpers
{
    public class CMySql
    {
        MySqlConnection connection;
        string dbPrefix;
        public CMySql(string hostname, string username, string password, string database, string prefix=null)
        {
            CConsole.PRINT("Connecting to database " + database + "-" + username + "@" + hostname);
            try
            {
                connection = new MySqlConnection("server="+hostname+";userid="+username+";password="+password+";database="+database+"");
                connection.Open();
                CConsole.GOOD("Connected.");
            }
            catch (MySqlException ex)
            {
                CConsole.ERROR("[MYSQL ERROR] " + ex.ToString());
            }
            this.dbPrefix = prefix;
        }
        public Query Query(string query)
        {
            try
            {
                if (query.Contains("INSERT") || query.Contains("UPDATE"))
                {
                    new MySqlCommand(query, connection).ExecuteNonQuery();
                    return null;
                }
                else
                {
                    return new Query(new MySqlCommand(query, connection).ExecuteReader());
                }
            }
            catch (MySqlException ex)
            {
                CConsole.DEBUG("[MYSQL ERROR] " + ex.ToString());
                return null;
            }
        }
    }
    public class Query
    {
        MySqlDataReader reader;
        public Query(MySqlDataReader reader)
        {
            this.reader = reader;
        }
        public bool Fetch(Row row)
        {
            row.reader = this.reader;
            return this.reader.Read();
        }
    }
    public class Row
    {
        public MySqlDataReader reader;
        public string String(string key)
        {
            return this.reader.GetString(key);
        }
        public string Int(string key)
        {
            return this.reader.GetString(key);
        }
        public ulong Int64(string key)
        {
            return this.reader.GetUInt64(key);
        }
    }
}
