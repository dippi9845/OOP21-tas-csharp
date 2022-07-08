namespace tas.Leonardo_Randacio.Model
{

    /// <summary>
    ///		Class that implements IMenuModel.
    /// </summary>
    public class MenuModel : IMenuModel
    {
        private readonly FakeJSON _JSONFile;
        private readonly int _maxLevels = 6;
        private int _mainScene = 1;
        private int _menuMode = 1;
        private int _currentLevel = 0;

        public MenuModel(FakeJSON newJSON)
        {
            this._JSONFile = newJSON;
        }

        public int GetMainScene()
        {
            return this._mainScene;
        }

        public void SetMainScene(int newMainScene)
        {
            this._mainScene = newMainScene;
        }

        public int GetMenuMode()
        {
            return this._menuMode;
        }

        public void SetMenuMode(int newMenuMode)
        {
            this._menuMode = newMenuMode;
        }

        public int GetCurrentLevel()
        {
            return this._currentLevel;
        }

        public void SetCurrentLevel(int newCurrentLevel)
        {
            this._currentLevel = newCurrentLevel;
        }

        public int GetNLevels()
        {
            return this._JSONFile.GetCurrentLevels();
        }

        public int GetMaxLevels()
        {
            return this._maxLevels;
        }
    }
}
