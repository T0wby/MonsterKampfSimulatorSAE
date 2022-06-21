using System;
using System.Collections.Generic;
using System.Text;

namespace Monsterkampfsimulator
{
    class Goblin : Monster
    {
        public Goblin()
        {
        }

        public Goblin(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
    }
}
