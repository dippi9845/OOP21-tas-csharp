
using tas.Gabos;
using tas.Gabos.enemy;
using tas.Gabos.utils;

namespace tas.Filippo_Di_Pietro.Test
{
    public class FakeEnemy : IEnemy
    {
        public FakeEnemy(Position pos, double health)
        {
            Position = pos;
            Health = health;
            Money = 0;
            Damage = 0;
            BodyDimension = new Size(50, 50);
            EntityName = "Fake enemy";
        }
        public double Health { get; private set; }

        public int Money { get; }

        public int Damage { get; }

        public Position Position { get; set; }

        public Size BodyDimension { get; }

        public string EntityName { get; }

        public void DealDamage(double damage) => Health -= damage;

        public bool IsDead() => Health <= 0;

        public bool IsPathCompleted() => false;

        public void MoveForward()
        {
            throw new System.NotImplementedException();
        }
    }
}
