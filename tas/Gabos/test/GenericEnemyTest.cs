using System;
using System.Collections.Generic;
using NUnit.Framework;
using tas.Gabos.utils;
using tas.Gabos.enemy;

namespace tas.Gabos.test
{
    [TestFixture]
    public class GenericEnemyTest
    {

        [Test]
        public void TestGetPosition()
        {
            Position pos = new Position(10, 10);
            IEnemy enemy = new GenericEnemy(new List<Position> { pos }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");

            Assert.AreEqual(pos.ToString(), enemy.Position.ToString());
        }

		[Test]
		public void TestMoveForward()
		{
			Position pos1 = new Position(10, 10);
			Position pos2 = new Position(20, 20);
			Position pos3 = new Position(10, 10);
			IEnemy enemy1 = new GenericEnemy(new List<Position> { pos1, pos2 }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");
			IEnemy enemy2 = new GenericEnemy(new List<Position> { pos1, pos3 }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");

			enemy1.MoveForward();
			enemy2.MoveForward();

			Assert.AreNotEqual(pos1.ToString(), enemy1.Position.ToString());
			Assert.AreEqual(pos1.ToString(), enemy2.Position.ToString());
		}

		[Test]
		public void TestDealDamage()
		{
			Position pos = new Position(10, 10);
			IEnemy enemy = new GenericEnemy(new List<Position> { pos }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");
			double maxHealth = enemy.Health;
			double damage = 5;

			enemy.DealDamage(5);

			Assert.AreEqual(maxHealth - damage, enemy.Health, 0.01);
		}

		[Test]
		public void TestIsDead()
		{
			Position pos = new Position(10, 10);
			IEnemy enemy = new GenericEnemy(new List<Position> { pos }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");

			Assert.IsFalse(enemy.IsDead());

			enemy.DealDamage(enemy.Health);

			Assert.IsTrue(enemy.IsDead());
		}

		[Test]
		public void TestHasCompletedPath()
		{
			Position pos1 = new Position(10, 10);
			Position pos2 = new Position(20, 20);
			IEnemy enemy1 = new GenericEnemy(new List<Position> { pos1 }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");
			IEnemy enemy2 = new GenericEnemy(new List<Position> { pos1, pos2 }, 1, 50, 10, 60, new Size(100, 100), "redEnemy");

			Assert.IsFalse(enemy2.IsPathCompleted());
			Assert.IsTrue(enemy1.IsPathCompleted());
		}

		[Test]
		public void TestCreationNoNode()
		{
			try
			{
				new GenericEnemy(new List<Position>(), 1, 50, 10, 60, new Size(100, 100), "redEnemy");
				Assert.Fail();
			}
			catch (ArgumentException) { }
			
		}

	}
}
