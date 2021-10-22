using System;
using System.Collections.Generic;
using System.Text;

namespace pantsChecker
{
    internal class Pants
    {
        public string Style { get; set; }
        public List<int> Size { get; set; }

        public Pants(string style)

        {
            Style = style;
            Size = new List<int>();
        }
    }
}