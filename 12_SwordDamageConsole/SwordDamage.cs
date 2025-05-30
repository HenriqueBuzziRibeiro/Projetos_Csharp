using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_SwordDamageConsole
{
    internal class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Damage { get; private set; }

        private int roll;
        public int Roll { get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            } 
        }

        private bool magic;
        public bool Magic { get { return magic; } 
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        private bool flaming;
        public bool FlamingDamage { get { return flaming; } 
            set
            {
                flaming = value;
                CalculateDamage();
            } 
        }

        public void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll* magicMultiplier) + BASE_DAMAGE;

            if(flaming) Damage = Damage + FLAME_DAMAGE;

        }

        public SwordDamage (int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
    }
}






/*}---------------    ISSO AQUI FOI SUBSTITUIDO POR LÓGICAS NOS SETS ----------------
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
}---------------    ISSO AQUI FOI SUBSTITUIDO POR LÓGICAS NOS SETS ----------------*/
