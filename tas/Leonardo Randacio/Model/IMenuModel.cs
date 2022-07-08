namespace tas.Leonardo_Randacio.Model
{

    /// <summary>
    ///		An interface for the menu model.
    /// </summary>
    public interface IMenuModel
    {

        /// <summary>
		///		Returns the main scene.
		/// </summary>
		/// <returns> the main scene.</returns>
		int GetMainScene();

		/// <summary>
		///		Sets the value of the main scene.
		/// </summary>
		/// <param name="newMainScene"></param>
		void SetMainScene(int newMainScene);

		/// <summary>
		///		Returns the menu mode.
		/// </summary>
		/// <returns> the menu mode.</returns>
		int GetMenuMode();

		/// <summary>
		///		Sets the menu mode.
		/// </summary>
		/// <param name="newMenuMode"></param>
		void SetMenuMode(int newMenuMode);

		/// <summary>
		///		Sets the current level.
		/// </summary>
		/// <param name="currentLevelIn"></param>
		void SetCurrentLevel(int currentLevelIn);

		/// <summary>
		///		Returns the current level.
		/// </summary>
		/// <returns> the current level.</returns>
		int GetCurrentLevel();

		/// <summary>
		///		Returns the number of levels currently stored.
		/// </summary>
		/// <returns> the number of levels.</returns>
		int GetNLevels();

		/// <summary>
		///		Returns the max number of levels allowed.
		/// </summary>
		/// <returns> the max number of levels.</returns>
		int GetMaxLevels();
	}
}
