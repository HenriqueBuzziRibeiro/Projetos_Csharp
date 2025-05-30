using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_SwordDamage
{
    internal class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1M;
            }

            Debug.WriteLine("MagicMultiplier: " + MagicMultiplier + "   Roll: " + Roll + "   Damage: " + Damage); //toda vez que marcarmos o checkBox ou desmarcarmos será impresso essa linha no 'Output'
        }

        public void SetFlaming(bool isFlamings)
        {  
            if (isFlamings)
            {
                FlamingDamage = FLAME_DAMAGE;
            }
        }
    }
}