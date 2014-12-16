using UnityEngine;
using System.Collections;

public class StartButtonController : MonoBehaviour {

	public AudioClip audioClip;
//	public GUIStyle buttonStyle;
	
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
		if ( GUI.Button(new Rect( Screen.width / 2, Screen.height - BUTTON_HEIGHT - 120 , BUTTON_WIDTH, BUTTON_HEIGHT), "start", buttonStyle) )
		{
//			audio.PlayOneShot(audioClip);
			SceneManager.instance.setColor( new Color(255, 255, 255) );
			SceneManager.instance.changeScene(SceneData.MENU_SCENE, 0.5f);
		}
	}
}
