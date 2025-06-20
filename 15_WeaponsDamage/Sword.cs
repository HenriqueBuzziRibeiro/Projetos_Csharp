using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_WeaponsDamage
{
    internal class SwordDamage : Weapon
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;

            if (Flaming) Damage = Damage + FLAME_DAMAGE;
        }

        public SwordDamage(int startingRoll) : base(0)
        {
            Roll = startingRoll;
            CalculateDamage();
        }
    }
}