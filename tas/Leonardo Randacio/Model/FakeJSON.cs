namespace tas.Leonardo_Randacio.Model
{

    /// <summary>
    ///		Class that simulates a JSON.
    /// </summary>
    public class FakeJSON
    {

        private int _currentLevels = 1;

        /// <summary>
        ///     Returns the number of current levels.
        /// </summary>
        /// <returns> the number of levels.</returns>
        public int GetCurrentLevels()
        {
            return this._currentLevels;
        }

        /// <summary>
		///		Sets the value of the current levels.
		/// </summary>
		/// <param name="newCurrentLevels"></param>
        public void SetCurrentLevels(int newCurrentLevels)
        {
            this._currentLevels = newCurrentLevels;
        }
	}
}
