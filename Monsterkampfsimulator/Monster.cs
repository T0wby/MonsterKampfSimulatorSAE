using System;
using System.Collections.Generic;
using System.Text;

namespace Monsterkampfsimulator
{
    abstract class Monster
    {
        float lifepoints;
        float attackpower;
        float defensepoints;
        float speed;
        int type;
        bool bChosen = false;
        bool bStartFight = false;

        public float Lifepoints
        {
            get { return this.lifepoints; }
            set { this.lifepoints = value; }
        }
        public float Attackpower
        {
            get { return this.attackpower; }
            set { this.attackpower = value; }
        }
        public float Defensepoints
        {
            get { return this.defensepoints; }
            set { this.defensepoints = value; }
        }
        public float Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public bool Chosen
        {
            get { return this.bChosen; }
            set { this.bChosen = value; }
        }

        public bool StartFight
        {
            get { return this.bStartFight; }
            set { this.bStartFight = value; }
        }

        public void Attack(Monster enemy)
        {
            float damage = this.Attackpower - enemy.Defensepoints;

            if (damage < 0)
            {
                damage = 0;
            }

            enemy.Lifepoints = enemy.Lifepoints - damage;
        }
    }
}
