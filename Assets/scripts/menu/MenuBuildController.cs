using UnityEngine;
using System.Collections;

public class MenuBuildController : MonoBehaviour {

	private const int BUTTON_WIDTH = 100;
	private const int BUTTON_HEIGHT = 40;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI ()
	{
		GUIStyle buttonStyle = new GUIStyle();
		buttonStyle.fontSize = 25;
		buttonStyle.normal.textColor = Color.white;
		
		// ボタンを表示する
		if ( GUI.Button(new Rect( Screen.width / 2, 100, BUTTON_WIDTH, BUTTON_HEIGHT), "build", buttonStyle) )
		{
			//			audio.PlayOneShot(audioClip);
			SceneManager.instance.setColor( new Color(255, 255, 255) );
//			SceneManager.instance.changeScene(SceneData.GAME_SCENE, 0.5f);
		}
	}
}
