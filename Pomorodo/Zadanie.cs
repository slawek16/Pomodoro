using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomorodo
{
    class Zadanie
    {
        public bool stan { get; set; }
        public string tresc { get; set; }

        public Zadanie(string tres)
        {
            tresc = tres;
            stan = false;
        }
        public override string ToString()
        {
            return tresc;
        }
    }
}
