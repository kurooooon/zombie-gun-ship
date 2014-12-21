using UnityEngine;
using System.Collections;

public class MenuStageSelectController : MonoBehaviour {

	private const int BUTTON_WIDTH = 100;
	private const int BUTTON_HEIGHT = 40;
	private ArrayList _stageList;

	Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
		_stageList = new ArrayList(); 
		for (int i = 1; i <= 10; i++)
		{
			_stageList.Add("stage" + i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI ()
	{
		GUIStyle titleStyle = new GUIStyle();
		titleStyle.font = GameConfig.APP_FONT;
		titleStyle.fontSize = 25;
		titleStyle.alignment = TextAnchor.UpperLeft;
		titleStyle.normal.textColor = Color.white;
		GUI.Label (new Rect (60, 250, BUTTON_WIDTH, BUTTON_HEIGHT), "Stage Select", titleStyle);

//		title.transform.position;

		int hMargin = 50;
		scrollPosition = GUI.BeginScrollView(new Rect(0, 300, Screen.width, Screen.height - 150), scrollPosition, new Rect(0, 0, 220, 700));

		GUIStyle buttonStyle = new GUIStyle();
		buttonStyle.fontSize = 25;
		buttonStyle.font = GameConfig.APP_FONT;
		buttonStyle.normal.textColor = Color.red;
		buttonStyle.alignment = TextAnchor.UpperCenter;
		for (int i = 0; i < _stageList.Count; i++)
		{
			string stageName = _stageList[i].ToString();
			if ( GUI.Button(new Rect((Screen.width - BUTTON_WIDTH) / 2, (BUTTON_HEIGHT + 10) * i, BUTTON_WIDTH, BUTTON_HEIGHT), stageName, buttonStyle) )
			{
				SceneManager.instance.changeScene(SceneData.GAME_SCENE, 0.5f);
			}
		}

		GUI.EndScrollView();
		return;

//		GUIStyle buttonStyle = new GUIStyle();
//		buttonStyle.fontSize = 25;
//		buttonStyle.normal.textColor = Color.white;
//
////		GameObject stageButtonContainer = new GameObject("stageButtonContainer");
////		stageButtonContainer.transform.parent = transform;
//		for (int i = 0; i < _stageList.Count; i++)
//		{
//			string stageName = _stageList[i].ToString();
//			// ボタンを表示する
//			if ( GUI.Button(new Rect( 20 + (BUTTON_WIDTH * i), Screen.height - BUTTON_HEIGHT - 120 , BUTTON_WIDTH, BUTTON_HEIGHT), stageName, buttonStyle) )
//			{
//				//			audio.PlayOneShot(audioClip);
//				SceneManager.instance.setColor( new Color(255, 255, 255) );
//				SceneManager.instance.changeScene(SceneData.GAME_SCENE, 0.5f);
//			}
//		}
	}
}
