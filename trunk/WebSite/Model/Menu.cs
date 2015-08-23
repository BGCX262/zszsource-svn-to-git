using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 菜单内容
    /// </summary>
    public class Menu
    {
        public Menu()
        {
        }
        public Menu(int _id)
        {
            id = _id;
        }
        public Menu(int _id,int lang)
        {
            id = _id;
            language = lang;
        }
        private int language;

        public int Language
        {
            get { return language; }
            set { language = value; }
        }
        private int id;      
        //名称
        private string name;
        //单位
        private string unit;
        //描述
        private string trait;
        //代码
        private string code;
        //分类
        private Type type;
        //菜价
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

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
        

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        

        public string Trait
        {
            get { return trait; }
            set { trait = value; }
        }
        

        public string Code
        {
            get { return code; }
            set { code = value; }
        }        
    }
}
