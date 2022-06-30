using tas.Gabos;

namespace tas.Filippo_Di_Pietro.ITower
{
    public interface ITower
    {
        public int Damage { get; }

        public int Radius { get; }

        public int Cost { get; }

        public int Delay { get; }

        string TowerName { get; }

        Position Pos { get; }
    }

    public abstract class AbstractBasicTower : ITower
    {
        
    }
}
