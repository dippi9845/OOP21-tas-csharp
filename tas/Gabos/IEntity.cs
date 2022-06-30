using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    internal interface IEntity
    {

        Position Position { get; }
        
        Tuple<int, int>  BodyDimension { get; }

        string EntityName { get; }

    }
}
