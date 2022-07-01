using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{

    /// <summary>
    ///    Class that handles some game attributes.
    /// </summary>
    public class GameSpecs
    {

        public int TickRate { get; }

        /// <summary>
        ///     Constructor that sets up game attributes.
        /// </summary>
        public GameSpecs()
        {
            TickRate = 60;
        }

    }
}
