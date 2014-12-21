using UnityEngine;
using System.Collections;

public class StartButtonController : MonoBehaviour
{
	private const int BUTTON_WIDTH = 100;
	private const int BUTTON_HEIGHT = 40;
	
	void OnGUI ()
	{
		GUIStyle buttonStyle = new GUIStyle();
		buttonStyle.font = GameConfig.APP_FONT;
		buttonStyle.fontSize = 25;
		buttonStyle.alignment = TextAnchor.UpperCenter;
		buttonStyle.normal.textColor = Color.red;

		if (GUI.Button(new Rect( (Screen.width - BUTTON_WIDTH) / 2, Screen.height - BUTTON_HEIGHT - 160 , BUTTON_WIDTH, BUTTON_HEIGHT), "Play Game", buttonStyle))
		{
			SceneManager.instance.setColor( new Color(255, 255, 255) );
			SceneManager.instance.changeScene(SceneData.MENU_SCENE, 0.5f);
		}
	}
}
