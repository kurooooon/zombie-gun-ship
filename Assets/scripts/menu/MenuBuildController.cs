using UnityEngine;
using System.Collections;

public class MenuBuildController : MonoBehaviour {

	private const int BUTTON_WIDTH = 100;
	private const int BUTTON_HEIGHT = 40;

	void OnGUI ()
	{
		GUIStyle buttonStyle = new GUIStyle();
		buttonStyle.fontSize = 25;
		buttonStyle.normal.textColor = Color.white;
		buttonStyle.font = GameConfig.APP_FONT;
		buttonStyle.alignment = TextAnchor.UpperLeft;

		GUI.Label(new Rect(60, 100, BUTTON_WIDTH, BUTTON_HEIGHT), "Curtomize", buttonStyle );

		buttonStyle.normal.textColor = Color.red;
		buttonStyle.alignment = TextAnchor.UpperCenter;
		if ( GUI.Button(new Rect( (Screen.width - BUTTON_WIDTH) / 2, 140, BUTTON_WIDTH, BUTTON_HEIGHT), "Build Weapon", buttonStyle) )
		{
			Debug.Log("no content");
			SceneManager.instance.setColor( new Color(255, 255, 255) );
		}
	}
}
