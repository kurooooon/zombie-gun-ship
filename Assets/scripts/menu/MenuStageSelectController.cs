using UnityEngine;
using System.Collections;

public class MenuStageSelectController : MonoBehaviour {

	private const int BUTTON_WIDTH = 100;
	private const int BUTTON_HEIGHT = 40;
	private ArrayList _stageList;

	// Use this for initialization
	void Start () {
		_stageList = new ArrayList(); 
		for (int i = 1; i <= 2; i++)
		{
			_stageList.Add("stage" + i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI ()
	{
		GUIStyle buttonStyle = new GUIStyle();
		buttonStyle.fontSize = 25;
		buttonStyle.normal.textColor = Color.white;

//		GameObject stageButtonContainer = new GameObject("stageButtonContainer");
//		stageButtonContainer.transform.parent = transform;
		for (int i = 0; i < _stageList.Count; i++)
		{
			string stageName = _stageList[i].ToString();
			// ボタンを表示する
			if ( GUI.Button(new Rect( 20 + (BUTTON_WIDTH * i), Screen.height - BUTTON_HEIGHT - 120 , BUTTON_WIDTH, BUTTON_HEIGHT), stageName, buttonStyle) )
			{
				//			audio.PlayOneShot(audioClip);
				SceneManager.instance.setColor( new Color(255, 255, 255) );
				SceneManager.instance.changeScene(SceneData.GAME_SCENE, 0.5f);
			}
		}
	}
}
