namespace Modulo17.Singleton.Example1
{
	// Singleton
	public class ScoreManager : Singleton<ScoreManager>
	{
		#region Singleton Pattern

		//private static ScoreManager _instance;

		//public static ScoreManager Instance
		//{
		//	get
		//	{
		//		if (_instance == null)
		//		{
		//			_instance = new ScoreManager();
		//		}

		//		return _instance;
		//	}
		//}

		#endregion

		public int Score { get; private set; }

		public void AddScore(int score)
		{
			Score += score;
		}
	}
}
