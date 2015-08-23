using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;
namespace DAL
{
    public class MenuService
    {
        public MenuService()
        {
        }
        public static Menu GetMenuById(int id, int language)
        {
            string sql = "SELECT LMenu" + language.ToString() + @".*, tblMenuItem.Price, tblItem_Type.MenuTypeId
                            FROM LMenu" + language.ToString() + @" INNER JOIN
                                  tblMenuItem ON LMenu" + language.ToString() + @".Id = tblMenuItem.Id INNER JOIN
                                  tblItem_Type ON LMenu" + language.ToString() + @".Id = tblItem_Type.MenuItemId
                            WHERE (LMenu" + language.ToString() + ".Id = " + id.ToString() + ") ";
            Menu menu =null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (sdr.Read())
                {
                    menu = new Menu(id);
                    menu.Language = language;
                    menu.Name = (string)sdr["name"];
                    menu.Price = (decimal)sdr["price"];
                    menu.Trait = (string)sdr["trait"];
                    menu.Unit = (string)sdr["unit"];
                    menu.Code = (string)sdr["Code"];
                    menu.Type = new Model.Type((int)sdr["MenuTypeId"]);
                }
            }
            return menu;
        }

        public static IList<Menu> GetMenusByType(int type, int language)
        {
            IList<Menu> menus = new List<Menu>();
            string sql = "SELECT LMenu" + language.ToString() + @".*, tblMenuItem.Price,tblItem_Type.MenuTypeId
                            FROM LMenu" + language.ToString() + @" INNER JOIN
                                  tblMenuItem ON LMenu" + language.ToString() + @".Id = tblMenuItem.Id INNER JOIN
                                  tblItem_Type ON LMenu" + language.ToString() + @".Id = tblItem_Type.MenuItemId
                            WHERE (tblItem_Type.MenuTypeId = " + type.ToString() + ") ";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    Menu menu = new Menu((int)sdr["id"]);

                    menu.Name = (string)sdr["name"];
                    menu.Price = (decimal)sdr["price"];
                    menu.Trait = (string)sdr["trait"];
                    menu.Unit = (string)sdr["unit"];
                    menu.Code = (string)sdr["Code"];
                    menu.Type = new Model.Type((int)sdr["MenuTypeId"]);
                    menu.Language = language;
                    menus.Add(menu);
                }
            }
            return menus;
        }
        public static IList<Menu> GetMenus(int language)
        {
            IList<Menu> menus=new List<Menu>();
            string sql = "SELECT LMenu" + language.ToString() + @".*, tblMenuItem.Price, tblItem_Type.MenuTypeId
                            FROM LMenu" + language.ToString() + @" INNER JOIN
                                  tblMenuItem ON LMenu" + language.ToString() + @".Id = tblMenuItem.Id INNER JOIN
                                  tblItem_Type ON LMenu" + language.ToString() + @".Id = tblItem_Type.MenuItemId";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    Menu menu = new Menu((int)sdr["id"]);
                    menu.Language = language;
                    menu.Name = (string)sdr["name"];
                    menu.Price = (decimal)sdr["price"];
                    menu.Trait = (string)sdr["trait"];
                    menu.Unit = (string)sdr["unit"];
                    menu.Code = (string)sdr["Code"];
                    menu.Type = new Model.Type((int)sdr["MenuTypeId"]);
                    menus.Add(menu);
                }
            }
            return menus;
        }
        public static Menu Add(Menu menu)
        {            
            string sql = "select Id from tblLanguage order by id";
            StringBuilder sqlAdd = new StringBuilder();
            StringBuilder sqlDel = new StringBuilder();
            int id = GetNewId();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    sqlAdd.Append(" insert into LMenu" + sdr[0].ToString() + " (id,name, unit, trait ,code) VALUES(" + id.ToString() + ",'" + menu.Name + "','" + menu.Unit + "','" + menu.Trait + "','" + menu.Code + "') ");
                    sqlDel.Append("delete LMenu" + sdr[0].ToString() + " where name='" + menu.Name + "");
                }
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sqlAdd.ToString());
            }
            return new Menu(id);
        }
        public static void Edit(Menu menu)
        {
            string sql = "update LMenu" + menu.Language.ToString() + " set name='" + menu.Name + "',Code='" + menu.Code + "',Unit='" + menu.Unit + "',Trait='" + menu.Trait + "' where id=" + menu.Id.ToString();
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
        public static void Delete(Menu menu)
        {
            string sql = "select Id from tblLanguage order by id";
            StringBuilder sqlDel = new StringBuilder();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (sdr.Read())
                {
                    sqlDel.Append(" delete LMenu" + menu.Language.ToString() + "  where name='" + menu.Name + "'");
                }
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sqlDel.ToString());
            }
        }
        private static int GetNewId()
        {
            string sql = "select top 1 id from LMenu0 order by id desc ";
            int i = (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql);
            return i + 1;
        }
    }
}
