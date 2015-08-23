using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class TypeService
    {
        public static Model.Type GetTypeById(int id,int language)
        {
            string sql = @"select LType" + language.ToString() + ".*,tblMenuType.OrderId from LType"
                + language.ToString() +
                " INNER JOIN tblMenuType ON tblMenuType.id=LType" + language.ToString() +
                ".id where tblMenuType.id =" + id.ToString();
            Model.Type type = new Model.Type();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (sdr.Read())
                {
                    type.Id = id;
                    type.Name = (string)sdr["name"];
                    type.Order = (int)sdr["orderid"];
                    type.Language = language;
                }
                else
                    type = null;
            }
            return type;
        }
        public static IList<Model.Type> GetAll(int language)
        {
            IList<Model.Type> types = new List<Model.Type>();
            string sql = "select LType" + language.ToString() + ".*,tblMenuType.OrderId from LType" + language.ToString() + 
                " INNER JOIN tblMenuType ON tblMenuType.id=LType" + language.ToString() +".id";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    Model.Type type = new Model.Type();
                    type.Id = (int)sdr["id"];
                    type.Name = (string)sdr["name"];
                    type.Order = (int)sdr["orderid"];
                    type.Language = language;
                    types.Add(type);
                }
            }
            return types;
        }
        public static void Add(Model.Type type)
        {
            string sql = "select Id from tblLanguage order by id";
            StringBuilder sqlAdd = new StringBuilder();
            StringBuilder sqlDel = new StringBuilder();
            int id = GetNewId();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    if (sdr[0].ToString() == type.Language.ToString())
                        sqlAdd.Append(" insert into LType" + sdr[0].ToString() + " (id,name) VALUES(" + id .ToString()+ ",'" + type.Name + "') ");
                    else
                        sqlAdd.Append(" insert into LType" + sdr[0].ToString() + " (id,name) VALUES(" + id.ToString() + ",'') ");
                    sqlDel.Append(" delete LType" + sdr[0].ToString() + " where id=" + type.Id.ToString() + " ");
                }
                sqlAdd.Append(" insert into tblMenuType(id,OrderId) values("+id.ToString()+","+type.Order.ToString()+") ");
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sqlAdd.ToString());
            } 
        }
        public static void Edit(Model.Type type)
        {
            string sql = @"update LType" + type.Language.ToString() + " set name='" + type.Name + "' where id=" + type.Id.ToString()+
                " update tblMenuType set OrderId=" + type.Order.ToString() + " where id=" + type.Id.ToString();

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }
        public static void Delete(Model.Type type)
        {
            string sql = "select Id from tblLanguage order by id";
            StringBuilder sqlDel = new StringBuilder();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    sqlDel.Append(" delete LType" + sdr[0].ToString() + "  where id=" + type.Id.ToString());
                }
                sqlDel.Append(" delete tblMenuItem where id=" + type.Id.ToString());
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sqlDel.ToString());
            }
        }
        private static int GetNewId()
        {
            string sql = "select top 1 id from LType0 order by id desc ";
            int i = (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql);
            return i + 1;
        }
    }
}
