using tas.Gabos;

namespace tas.Filippo_Di_Pietro
{
    /// <summary>
    /// This interface model a generic tower on the map
    /// </summary>
    public interface ITower : IEntity
    {
        /// <summary>
        /// Damage of the tower
        /// </summary>
        public int Damage { get; }

        /// <summary>
        /// Radius of action of the tower
        /// </summary>
        public int Radius { get; }

        /// <summary>
        /// Cost for buildingthat tower
        /// </summary>
        public int Cost { get; }

        /// <summary>
        /// Delay of attack of the tower
        /// </summary>
        public int Delay { get; }

        /// <summary>
        /// Name of the tower
        /// </summary>
        public string TowerName { get; }

        /// <summary>
        /// Current position ofthe tower
        /// </summary>
        public Position Pos { get; }

        /// <summary>
        /// Generic behavior of the tower
        /// </summary>
        void Compute();
    }
}
