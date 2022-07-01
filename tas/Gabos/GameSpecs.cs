using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    internal class GameSpecs
    {

        private int _tickRate;

        public GameSpecs()
        {
            this._tickRate = 60;
        }

        public int GetTickRate() => this._tickRate;


    }
}
