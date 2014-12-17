using UnityEngine;
using System.Collections;

public class ZombieScoutingController : MonoBehaviour {

	private ZombieController _controller;
	private bool _isAlive;
	private bool _scouting;
	private GameObject _targetHuman;

	// Use this for initialization
	void Start () {
//		Debug.Log("start scout");
		_controller = gameObject.transform.parent.GetComponent<ZombieController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setController()
	{
//		_controller = gameObject.transform.parent.GetComponent<ZombieController>();
	}

	void OnTriggerEnter (Collider col) {
		if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN_DETECTION) >= 0 && !_scouting)
		{
//			Debug.Log("scout target!");
//			_scouting = true;
//			_targetHuman = col.gameObject;
			_controller.findTarget(col.gameObject.transform.parent.gameObject);
		}
	}
}
