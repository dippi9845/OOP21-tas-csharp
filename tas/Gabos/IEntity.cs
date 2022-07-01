using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    /// <summary>
    ///     An interface that models an Entity
    /// </summary>
    public interface IEntity
    {

        /// <summary>
        ///     The position of the entity.
        /// </summary>
        Position Position { get; }
        
        /// <summary>
        ///     The body dimension of the entity.
        /// </summary>
        Tuple<int, int>  BodyDimension { get; }

        /// <summary>
        ///     The name of the entity
        /// </summary>
        string EntityName { get; }

    }
}
