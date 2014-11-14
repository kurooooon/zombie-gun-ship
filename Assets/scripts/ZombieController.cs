using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	private GameObject _body;
	private GameObject _goal;
	private NavMeshAgent _agent;
	private ArrayList _animList;

	// Use this for initialization
	void Start () {
		_body = gameObject.transform.FindChild("ZombieBody").gameObject; 
		_animList = new ArrayList();
		foreach (AnimationState anim in _body.animation) {
			Debug.Log(anim.name);
			_animList.Add(anim);
		}

//		_animList = _body.GetComponent("Animations") as Animation[];
//		_animList = _body. 
		_goal = GameObject.Find("Goal");
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		_agent.SetDestination(_goal.transform.position);
	}
}
