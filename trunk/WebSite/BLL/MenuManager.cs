using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class MenuManager
    {
        public static Menu GetMenuById(int id, int language)
        {
            if (DAL.LanguageService.GetLanguageById(language)!=null)
                return DAL.MenuService.GetMenuById(id,language);
            return null;
        }
        public static IList<Menu> GetMenus(int language)
        {
            if (DAL.LanguageService.GetLanguageById(language) != null)
                return DAL.MenuService.GetMenus(language);
            return null;
        }
        public static void AddNew(Menu menu)
        {
            MenuService.Add(menu);
        }
        public static void Delete(Menu menu)
        {
            MenuService.Delete(menu);
        }
        public static void Update(Menu menu)
        {
            MenuService.Edit(menu);
        }
    }
}
