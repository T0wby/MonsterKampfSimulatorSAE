using System;
using System.Collections.Generic;
using System.Text;

namespace Monsterkampfsimulator
{
    class Troll : Monster
    {
        public Troll()
        {
        }

        public Troll(int number, string name)
        {
            this._number = number;
            this._name = name;
        }
    }
}
