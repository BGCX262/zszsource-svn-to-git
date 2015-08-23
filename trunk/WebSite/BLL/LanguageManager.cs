using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class LanguageManager
    {
        public static void Update(Language language)
        {
            DAL.LanguageService.Edit(language);
        }
        public static IList<Language> GetLanguages()
        {
            return DAL.LanguageService.GetAll();
        }
        public static void Add(Language language)
        {
            DAL.LanguageService.Add(language);
        }
        public static void Delete(Language language)
        {
            DAL.LanguageService.Delete(language);
        }
        public static Language GetLanguageById(int id)
        {
            return DAL.LanguageService.GetLanguageById(id);
        }
    }
}
