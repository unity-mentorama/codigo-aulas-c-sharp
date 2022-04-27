using System;
using UnityEngine;

namespace Modulo6
{
	public class Structs : MonoBehaviour
	{
		[Serializable]
		struct PlayerData
		{
			long Mana;
			public byte Health;
			public byte Score;
		}

		struct Coordinates
		{
			public float x;
			public float y;
			public float z;
		}

		[SerializeField]
		PlayerData playerData;

		[SerializeField]
		PlayerData[] playersData;

		void Start()
		{
			playerData.Health = 3;

			playerData = new PlayerData
			{
				Health = 3,
				Score = 4
			};

			playerData = default;

			PlayerData newPlayerData = playerData;
			newPlayerData.Health = 5;
		}
	}
}