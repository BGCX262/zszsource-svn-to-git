using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class LanguageService
    {
        public static Language GetLanguageById(int id)
        {
            string sql = "select * from tblLanguage where id ="+id.ToString();
            Language language = new Language();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (sdr.Read())
                {
                    language.Id = (int)sdr["id"];
                    language.Name = (string)sdr["name"];
                }
                else
                    language = null;
            }
            return language;
        }
        public static IList<Language> GetAll()
        {
            IList<Language> languages = new List<Language>();
            string sql = "select * from tblLanguage ";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    Language language = new Language();
                    language.Id = (int)sdr["id"];
                    language.Name = (string)sdr["name"];
                    languages.Add(language);
                }
            }
            return languages;
        }
        public static void Add(Language language)
        {
            int id = GetNewId();
            string sql = @" insert into  tblLanguage(id,name)  values ("+id+",'" + language.Name + "')";
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }
        public static void Edit(Language language)
        {
            string sql = "update tblLanguage set name='"+language.Name+"' where id=" + language.Id.ToString();
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }
        public static void Delete(Language language)
        {
            string sql = "delete tblLanguage where id="+language.Id.ToString();
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }
        private static int GetNewId()
        {
            string sql = "select top 1 id from tblLanguage order by id desc ";
            int i = (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql);
            return i+1;
        }

    }
}
