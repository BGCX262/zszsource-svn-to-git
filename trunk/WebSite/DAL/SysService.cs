using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class SysService
    {
        public static Sys GetSys(string name, int language)
        {
            string sql = "select * from LSys"+language.ToString()+" where name ='"+name.ToString()+"'";
            Sys sys = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (sdr.Read())
                {
                    sys = new Sys();
                    sys.Name = (string)sdr["name"];
                    sys.Value = (string)sdr["Value"];
                    sys.Language = language;
                }
            }
            return sys;
        }
        public static IList<Sys> GetAll(int language)
        {
            string sql = "select * from LSys" + language.ToString() + " order by name";
            IList<Sys> syss = new List<Sys>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    Sys sys = new Sys();
                    sys.Name = (string)sdr["name"];
                    sys.Value = (string)sdr["Value"];
                    sys.Language = language;
                    syss.Add(sys);
                }
            }
            return syss;
        }
        public static void Add(Sys sys)
        {
            string sql = "select Id from tblLanguage order by id";
            StringBuilder sqlAdd = new StringBuilder();
            StringBuilder sqlDel = new StringBuilder();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    if (sdr[0].ToString() == sys.Language.ToString())
                        sqlAdd.Append(" insert into LSys" + sdr[0].ToString() + " (name,value) VALUES('" + sys.Name + "','" + sys.Value + "') ");
                    else
                        sqlAdd.Append(" insert into LSys" + sdr[0].ToString() + " (name,value) VALUES('" + sys.Name + "','') ");
                    sqlDel.Append(" delete LSys" + sdr[0].ToString() + " where name='" + sys.Name + "");
                }
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sqlAdd.ToString());
            }            
        }
        public static void Edit(Sys sys)
        {
            string sql = " update LSys" + sys.Language.ToString() + " set value='" + sys.Value + "' where name='" + sys.Name + "'";
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public static void Delete(Sys sys)
        {
            string sql = "select Id from tblLanguage order by id";
            StringBuilder sqlDel = new StringBuilder();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    sqlDel.Append(" delete LSys" + sdr[0].ToString() + "  where name='" + sys.Name + "'");
                }
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sqlDel.ToString());
            }  
        }
    }
}
