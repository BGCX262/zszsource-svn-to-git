using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class TypeManager
    {
        public static void Update(Model.Type type)
        {
            DAL.TypeService.Edit(type);
        }
        public static IList<Model.Type> GetTypes(int language)
        {
            return DAL.TypeService.GetAll(language);
        }
        public static void Add(Model.Type type)
        {
            DAL.TypeService.Add(type);
        }
        public static void Delete(Model.Type type)
        {
            DAL.TypeService.Delete(type);
        }
        public static Model.Type GetTypeById(int id, int language)
        {
            return DAL.TypeService.GetTypeById(id, language);
        }
        public static IList<Model.Type> GetOne(int id)
        {
            IList<Language> languages = LanguageService.GetAll();
            IList<Model.Type> types = new List<Model.Type>();
            foreach (Language language in languages)
            {
                Model.Type type= GetTypeById(id, language.Id);
                types.Add(type);
            }
            return types;
        }
    }
}
