using UnityEngine;
using System.Collections;

public class ScoreUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUIText kill = GameObject.Find("KillZombie").GetComponent<GUIText>();
		kill.text = "Kill Zombie: " + GameData.killZombie;
		GUIText getMoney = GameObject.Find("GetMoney").GetComponent<GUIText>();
		getMoney.text = "Get Money: " + GameData.getMoney;
		GUIText totalMoney = GameObject.Find("TotalMoney").GetComponent<GUIText>();
		totalMoney.text = "Total Money: " + GameData.totalMoney;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if ( GUI.Button(new Rect( (Screen.width - 100) / 2, Screen.height - 200, 100, 40), "retry") )
			SceneManager.instance.changeScene(SceneData.GAME_SCENE, 0.5f);
		if ( GUI.Button(new Rect( (Screen.width - 100) / 2, Screen.height - 100, 100, 40), "menu") )
			SceneManager.instance.changeScene(SceneData.MENU_SCENE, 0.5f);
	}
}
