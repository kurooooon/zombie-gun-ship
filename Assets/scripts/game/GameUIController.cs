using UnityEngine;
using System.Collections;

public class GameUIController : MonoBehaviour {

	private GUIText _life;
	private GUIText _money;
	private GUIText _bullet;
	
	private GameController _controller;
	
	void Start ()
	{
		_controller = GameObject.Find(GameConfig.GAME_CONTROLLER).GetComponent<GameController>();

		_life = gameObject.transform.FindChild("LifeUI").GetComponent<GUIText>();
		_life.text = "LIFE: " + GameData.life;
		_money = gameObject.transform.FindChild("MoneyUI").GetComponent<GUIText>();
		_money.text = "MONEY: " + GameData.getMoney;
		_bullet = gameObject.transform.FindChild("BulletUI").GetComponent<GUIText>();
		_bullet.text = "BULLET: " + GameData.bulletData.slot;

		setFont(_life);
		setFont(_money);
		setFont(_bullet);
	}

	void Update ()
	{
		_life.text = "LIFE: " + GameData.life;
		_money.text = "MONEY: " + GameData.getMoney;
		if (GameData.bulletData.slot <= 0)
			slotReload();
		else
			slotDefault();
	}

	void OnGUI()
	{

		if ( GUI.Button(new Rect(Screen.width - 115, Screen.height - 45, 100, 40), "exit") )
		{
			SceneManager.instance.changeScene(SceneData.SCORE_SCENE, 0.5f);
		}

		if ( GUI.Button(new Rect(0, Screen.height - 45, 100, 40), "bomb") )
		{
			_controller.setBullet(GameConfig.BULLET_BOMB);
//			SceneManager.instance.changeScene(SceneData.SCORE_SCENE, 0.5f);
		}
		if ( GUI.Button(new Rect(0, Screen.height - 90, 100, 40), "rifle") )
		{
			_controller.setBullet(GameConfig.BULLET_RIFLE);
//			SceneManager.instance.changeScene(SceneData.SCORE_SCENE, 0.5f);
		}

		if ( GUI.Button(new Rect(105, Screen.height - 90, 100, 40), "ZoomIn") )
		{
			_controller.setZoom(GameConfig.ZOOM_IN);
		}
		if ( GUI.Button(new Rect(105, Screen.height - 45, 100, 40), "ZoomOut") )
		{
			_controller.setZoom(GameConfig.ZOOM_OUT);
		}
	}

	public void slotReload()
	{
		_bullet.text = "BULLET: Reload...";
		_bullet.color = Color.red;
	}

	public void slotDefault()
	{
		_bullet.text = "BULLET: " + GameData.bulletData.slot;
		_bullet.color = Color.white;
	}

	private void setFont(GUIText text)
	{
		text.font = GameConfig.APP_FONT;
	}
}
