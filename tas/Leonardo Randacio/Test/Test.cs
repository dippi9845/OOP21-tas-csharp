using tas.Leonardo_Randacio.Model;
using NUnit.Framework;
using System;

namespace tas.Leonardo_Randacio.Test
{

    [TestFixture]
    public class Test
    {
        private readonly FakeJSON _fakeJSON = new FakeJSON();

        private Random _random = new Random();

        [Test]
        public void MainSceneTest()
        {
            IMenuModel menuModel = new MenuModel(this._fakeJSON);

            int testInt = this._random.Next(10);
            menuModel.SetMainScene(testInt);
            Assert.AreEqual(menuModel.GetMainScene(), testInt);
        }

        [Test]
        public void MenuModeTest()
        {
            IMenuModel menuModel = new MenuModel(this._fakeJSON);

            int testInt = this._random.Next(10);
            menuModel.SetMenuMode(testInt);
            Assert.AreEqual(menuModel.GetMenuMode(), testInt);
        }

        [Test]
        public void CurrentLevelTest()
        {
            IMenuModel menuModel = new MenuModel(this._fakeJSON);

            int testInt = this._random.Next(10);
            menuModel.SetCurrentLevel(testInt);
            Assert.AreEqual(menuModel.GetCurrentLevel(), testInt);
        }

        [Test]
        public void NLevelsTest()
        {
            IMenuModel menuModel = new MenuModel(this._fakeJSON);

            Assert.AreEqual(menuModel.GetNLevels(), this._fakeJSON.GetCurrentLevels());
        }

    }
}
