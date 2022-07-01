using tas.Gabos;

namespace tas.Filippo_Di_Pietro
{
    public interface ITower : IEntity
    {
        public int Damage { get; }

        public int Radius { get; }

        public int Cost { get; }

        public int Delay { get; }

        public string TowerName { get; }

        public Position Pos { get; }

        void Compute();
    }
}
