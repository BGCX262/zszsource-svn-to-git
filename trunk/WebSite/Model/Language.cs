using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Language
    {
        public Language()
        {
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
    }
}
