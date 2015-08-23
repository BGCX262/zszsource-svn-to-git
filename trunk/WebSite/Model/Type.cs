using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 菜分类，比如：川菜
    /// </summary>
    public class Type
    {
        public Type()
        {
        }
        public Type(int _id)
        {
            id = _id;
        }
        public Type(int _id, int lang)
        {
            id = _id;
            language = lang;
        }

        private int id;


        private string name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int language;

        public int Language
        {
            get { return language; }
            set { language = value; }
        }
        private int order;

        public int Order
        {
            get { return order; }
            set { order = value; }
        }
    }
}
