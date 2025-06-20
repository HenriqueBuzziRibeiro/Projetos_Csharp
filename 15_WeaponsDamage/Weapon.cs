using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _15_WeaponsDamage
{
    internal class Weapon
    {

        public int Damage { get; protected set; } //protected para as classes filhas terem acesso

        private int roll;
        public int Roll { 
            get { return roll; } 
            set 
            {
                roll = value;
                CalculateDamage();
            } 
        }

        private bool magic;
        public bool Magic 
        {
            get { return magic; } 
            set
            {
                magic = value;
                CalculateDamage();
            } 
        }

        private bool flaming;
        public bool Flaming 
        {
            get { return flaming; }
            set 
            { 
                flaming = value;
                CalculateDamage();
            }
        }

        //Subclasse sobreescreve esse método
        protected virtual void CalculateDamage()
        {

        }

        public Weapon(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
    }
}