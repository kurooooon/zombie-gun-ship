using UnityEngine;
using System.Collections;

public class GameData : BaseSingleton<GameData>
{
	private string _mode = GameConfig.MODE_GAME;
	private int _life = GameConfig.GAME_LIFE;
	private int _getMoney = 0;
	private int _totalMoney = 0;
	private int _killZombie = 0;
	private BaseBulletData _bulletData;
//	private int _totalMoney = 0;
	
	public void Awake()
	{
		if(this != instance)
		{
			Destroy(this);
			return;
		}

		_totalMoney =  PlayerPrefs.GetInt(GameConfig.KEY_TOTAL_MONEY);
		DontDestroyOnLoad(this.gameObject);
	}    
	
//	public static void init()
//	{
//		instance._init();
//	}

	public static BaseBulletData bulletData
	{
		set{ instance._bulletData = value; }
		get{ return instance._bulletData; }
	}
	
	public static int life
	{
		set{ instance._life = value; }
		get{ return instance._life; }
	}

	public static int killZombie
	{
		set{ instance._killZombie = value; }
		get{ return instance._killZombie; }
	}

	public static int getMoney
	{
		set{ instance._getMoney = value; }
		get{ return instance._getMoney; }
	}

	public static int totalMoney
	{
//		set{ instance._totalMoney = value; }
		get{ return instance._totalMoney ; }
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