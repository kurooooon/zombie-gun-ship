using UnityEngine;
using System.Collections;

public class GameConfig : MonoBehaviour {

	public static string MODE_TITLE = "modeTitle";
	public static string MODE_STAGE_SELECT = "modeStageSelect ";
	public static string MODE_GAME = "modeGame";
	public static string MODE_SCORE = "modeScore";

	public static string GAME_CONTROLLER = "GameController";

	public static string BULLET_CONTROLLER = "BulletController";
	public static string BULLET_CODE = "bullet";
	public static string TAG_SCOUTING = "zombieScouting";
	public static string TAG_HUMAN = "human";
	public static string TAG_HUMAN_DETECTION = "detectionHuman";
	public static string TAG_GOAL = "goal";

	public static string KEY_TOTAL_MONEY = "save.totalMoney";

	public static string BULLET_BOMB = "bomb";
	public static string BULLET_RIFLE = "rifle";

	public static string ZOOM_IN = "zoomIn";
	public static string ZOOM_OUT = "zoomOut";

	public static int GAME_LIFE = 3;
	public static int HUMAN_LIFE = 5;
	public static int DEATH_COIN = 5;
}
