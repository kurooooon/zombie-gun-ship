using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
	
	void Start ()
	{
		//record total money
		PlayerPrefs.SetInt(GameConfig.KEY_TOTAL_MONEY, GameData.totalMoney + GameData.getMoney);
	}

	void Update ()
	{
	
	}
}