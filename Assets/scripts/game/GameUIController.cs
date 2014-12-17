using UnityEngine;
using System.Collections;

public class GameUIController : MonoBehaviour {

	private GUIText _life;
	private GUIText _money;
	// Use this for initialization
	void Start () {
		_life = gameObject.transform.FindChild("LifeUI").GetComponent<GUIText>();
		_life.text = "LIFE: " + GameData.life;
		_money = gameObject.transform.FindChild("MoneyUI").GetComponent<GUIText>();
		_money.text = "MONEY: " + GameData.getMoney;
	}
	
	// Update is called once per frame
	void Update () {
		_life.text = "LIFE: " + GameData.life;
		_money.text = "MONEY: " + GameData.getMoney;
	}
}
