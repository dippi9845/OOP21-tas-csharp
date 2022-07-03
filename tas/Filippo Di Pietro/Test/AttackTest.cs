using NUnit.Framework;
using System.Collections.Generic;
using tas.Filippo_Di_Pietro.Tower;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro.Test
{
    [TestFixture]
    public class AttackTest
    {
        static int DEFAULTDAMAGE = 50;
        static int DEFAULTHEALTH = DEFAULTDAMAGE * 2;
        [Test]
        public void BasicTowerAttack()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);
            
            enemyList.Add(e1);
            enemyList.Add(e2);

            ITower tower = new BasicTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre di Prova", enemyList);
            
            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());

            enemyList.Remove(e1);

            tower.Compute();


            Assert.IsTrue(e2.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e2.IsDead());

        }

        [Test]
        public void BasicTowerAttackTooFar()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);

            enemyList.Add(e1);

            ITower tower = new BasicTower(new Position(70, 70), DEFAULTDAMAGE, 1, 0, 0, "Torre di Prova", enemyList);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            enemyList.Remove(e1);
        }

        [Test]
        public void BasicTowerAttackTooFar2()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            FakeEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);

            enemyList.Add(e1);

            ITower tower = new BasicTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre di Prova", enemyList);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);

            e1.Position = new Position(1000, 1000);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);

            enemyList.Remove(e1);
        }

        [Test]
        public void MultipleTowerAttack()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);

            ITower tower = new BasicMultipleTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre Di Prova", enemyList, 2);

            enemyList.Add(e1);
            enemyList.Add(e2);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.IsDead());
        }
        
        [Test]
        public void MultipleTowerAttackTooFar()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(1000, 1000), DEFAULTHEALTH);

            ITower tower = new BasicMultipleTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre Di Prova", enemyList, 2);

            enemyList.Add(e1);
            enemyList.Add(e2);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.Health == DEFAULTHEALTH);
        }

        [Test]
        public void MultipleTowerAttackTooFar2()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            FakeEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);

            ITower tower = new BasicMultipleTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre Di Prova", enemyList, 2);

            enemyList.Add(e1);
            enemyList.Add(e2);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);

            e2.Position = new Position(1000, 1000);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);
        }

        [Test]
        public void MultipleTowerMaxTarget()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);
            IEnemy e3 = new FakeEnemy(new Position(102, 102), DEFAULTHEALTH);

            ITower tower = new BasicMultipleTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre Di Prova", enemyList, 2);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.IsDead());
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);
        }

        [Test]
        public void AreaTowerMaxTarget()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);
            IEnemy e3 = new FakeEnemy(new Position(102, 102), DEFAULTHEALTH);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            ITower tower = new BasicAreaTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "", enemyList, 2, 50);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.IsDead());
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);
        }

        [Test]
        public void AreaTowerAttack()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);
            IEnemy e3 = new FakeEnemy(new Position(102, 102), DEFAULTHEALTH);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            ITower tower = new BasicAreaTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "", enemyList, 3, 50);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e3.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.IsDead());
            Assert.IsTrue(e3.IsDead());
        }

        [Test]
        public void AreaTowerAttackTooFar()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);
            IEnemy e3 = new FakeEnemy(new Position(102, 102), DEFAULTHEALTH);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            ITower tower = new BasicAreaTower(new Position(70, 70), DEFAULTDAMAGE, 10, 0, 0, "", enemyList, 3, 50);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);
            Assert.IsTrue(e2.Health == DEFAULTHEALTH);
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);
            Assert.IsTrue(e2.Health == DEFAULTHEALTH);
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);
        }

        [Test]
        public void AreaTowerAttackTooFarFromFirstRange()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(125, 125), DEFAULTHEALTH);
            IEnemy e3 = new FakeEnemy(new Position(126, 126), DEFAULTHEALTH);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            ITower tower = new BasicAreaTower(new Position(95, 95), DEFAULTDAMAGE, 10, 0, 0, "", enemyList, 3, 50);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e3.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.IsDead());
            Assert.IsTrue(e3.IsDead());
        }

        [Test]
        public void AreaTowerAttackTooFarByMovement()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(125, 125), DEFAULTHEALTH);
            FakeEnemy e3 = new FakeEnemy(new Position(126, 126), DEFAULTHEALTH);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            ITower tower = new BasicAreaTower(new Position(95, 95), DEFAULTDAMAGE, 10, 0, 0, "", enemyList, 3, 50);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e3.Health < DEFAULTHEALTH / 2 + 1);

            e3.Position = new Position(1000, 1000);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.IsDead());
            Assert.IsTrue(e3.Health < DEFAULTHEALTH / 2 + 1);
        }

        [Test]
        public void AreaTowerAttackSingle()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(1000, 1000), DEFAULTHEALTH);
            FakeEnemy e3 = new FakeEnemy(new Position(1000, 1000), DEFAULTHEALTH);

            enemyList.Add(e1);
            enemyList.Add(e2);
            enemyList.Add(e3);

            ITower tower = new BasicAreaTower(new Position(95, 95), DEFAULTDAMAGE, 10, 0, 0, "", enemyList, 3, 50);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);
            Assert.IsTrue(e2.Health == DEFAULTHEALTH);
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);

            e3.Position = new Position(1000, 1000);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());
            Assert.IsTrue(e2.Health == DEFAULTHEALTH);
            Assert.IsTrue(e3.Health == DEFAULTHEALTH);
        }
    }
}
