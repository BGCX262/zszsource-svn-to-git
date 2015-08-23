using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// �˵�����
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
        //����
        private string name;
        //��λ
        private string unit;
        //����
        private string trait;
        //����
        private string code;
        //����
        private Type type;
        //�˼�
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
