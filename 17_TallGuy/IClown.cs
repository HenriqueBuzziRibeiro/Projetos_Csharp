using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_TallGuy
{
    internal interface IClown
    {
        string FunnyThingIHave { get; }


        void Honk(); //na interface não precisa adicionar public e abstract, pois vem assim por padrão



    }
}
