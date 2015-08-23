using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class SysManager
    {
        public static Sys GetSysById(string name, int language)
        {
            if (DAL.LanguageService.GetLanguageById(language) != null)
                return DAL.SysService.GetSys(name, language);
            return null;
        }
        public static IList<Sys> GetSyss(int language)
        {
            if (DAL.LanguageService.GetLanguageById(language) != null)
                return DAL.SysService.GetAll(language);
            return null;
        }
        public static void Add(Sys sys)
        {
            if (DAL.LanguageService.GetLanguageById(sys.Language) != null)
                DAL.SysService.Add(sys);
        }
        public static void Update(Sys sys)
        {
            if (DAL.LanguageService.GetLanguageById(sys.Language) != null)
                DAL.SysService.Edit(sys);
        }
        public static void Delete(Sys sys)
        {
            DAL.SysService.Delete(sys);
        }
        public static IList<Sys> GetOne(string name)
        {
            IList<Language> languages = LanguageService.GetAll();
            IList<Model.Sys> syss = new List<Model.Sys>();
            foreach (Language language in languages)
            {
                Model.Sys sys = GetSysById(name, language.Id);
                if(sys!=null)
                    syss.Add(sys);
            }
            return syss;
        }
    }
}
