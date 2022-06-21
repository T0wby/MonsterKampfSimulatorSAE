using System;
using System.Collections.Generic;
using System.Text;

namespace Monsterkampfsimulator
{
    class Ork : Monster
    {
        public Ork()
        {
        }
        public Ork(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
    }
}
