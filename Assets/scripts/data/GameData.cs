using UnityEngine;
using System.Collections;

public class GameData : BaseSingleton<GameData>
{
	private string _mode = GameConfig.MODE_GAME;
	private int _life = GameConfig.GAME_LIFE;
	private int _getMoney = 0;
//	private int _totalMoney = 0;
	
	public void Awake()
	{
		if(this != instance)
		{
			Destroy(this);
			return;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}    
	
//	public static void init()
//	{
//		instance._init();
//	}
	
	public static int life
	{
		set{ instance._life = value; }
		get{ return instance._life; }
	}

	public static int getMoney
	{
		set{ instance._getMoney = value; }
		get{ return instance._getMoney; }
	}
	
//	public static int highScore
//	{
//		get
//		{
//			return PlayerPrefs.GetInt(GameConfig.SCORE_KEY); 
//		}
//	}
	
	public static string mode
	{
		set
		{
			instance._mode = value;
			Debug.Log("currentMode: " + value);
		}
		get{ return instance._mode; }
	}
	
//	void _init()
//	{
//		_coinCount = INIT_COIN; 
//	}
}