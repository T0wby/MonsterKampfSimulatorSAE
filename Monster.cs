using System;
using System.Collections.Generic;
using System.Text;

namespace Monsterkampfsimulator
{
    abstract class Monster
    {
        protected float _lifepoints;
        protected float _attackpower;
        protected float _defensepoints;
        protected float _speed;
        protected float _number;
        protected string _name;
        protected bool _bChosen = false;
        protected bool _bStartFight = false;

        #region Properties
        /** Properties **/
        public float Lifepoints
        {
            get { return this._lifepoints; }
            set { this._lifepoints = value; }
        }
        public float Attackpower
        {
            get { return this._attackpower; }
            set { this._attackpower = value; }
        }
        public float Defensepoints
        {
            get { return this._defensepoints; }
            set { this._defensepoints = value; }
        }
        public float Speed
        {
            get { return this._speed; }
            set { this._speed = value; }
        }

        public float Number
        {
            get { return this._number; }
        }

        public string Name
        {
            get { return this._name; }
        }

        public bool Chosen
        {
            get { return this._bChosen; }
            set { this._bChosen = value; }
        }

        public bool StartFight
        {
            get { return this._bStartFight; }
            set { this._bStartFight = value; }
        }
        #endregion

        /// <summary>
        /// Deducts liefepoints from the enemy
        /// </summary>
        /// <param name="enemy">Target that will be attacked</param>
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
