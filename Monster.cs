using System;
using System.Collections.Generic;
using System.Text;

namespace Monsterkampfsimulator
{
    abstract class Monster
    {
        protected float lifepoints;
        protected float attackpower;
        protected float defensepoints;
        protected float speed;
        protected float number;
        protected string name;
        protected bool bChosen = false;
        protected bool bStartFight = false;

        /** Properties **/
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

        public float Number
        {
            get { return this.number; }
        }

        public string Name
        {
            get { return this.name; }
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

        /** Attack function **/
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
