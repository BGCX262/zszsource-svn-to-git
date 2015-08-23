using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //按钮显示的文字
    public class Sys
    {
        public Sys()
        {
        }
        public Sys(string _name)
        {
            name = _name;
        }
        public Sys(string _name, int lang)
        {
            name = _name;
            language = lang;
        }

        private string name;
        private string value;
        private int language;

        public int Language
        {
            get { return language; }
            set { language = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

    }
}
