namespace tas.Gabos.enemy
{
    internal interface IEnemyBuilder
    {

        /// <summary>
		///		Returns a red enemy.
		/// </summary>
		/// <returns> The red enemy.</returns>
		IEnemy SpawnRedEnemy();

		/// <summary>
		///		Returns a green enemy.
		/// </summary>
		/// <returns> The green enemy.</returns>
		IEnemy SpawnGreenEnemy();

		/// <summary>
		///		Returns a pink enemy.
		/// </summary>
		/// <returns> The pink enemy.</returns>
		IEnemy SpawnPinkEnemy();
        
	}
}
