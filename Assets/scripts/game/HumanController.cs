using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour {

	private GameObject _body;
	private GameObject _goal;
	private NavMeshAgent _agent;
	private ArrayList _animList; 
	private bool _isAlive;
	private bool _scouted;
	
	// Use this for initialization
	void Start () {
		_isAlive = true;
		_scouted = false;

		_body = gameObject.transform.FindChild("MAX").gameObject; 
		_animList = new ArrayList(); 
		foreach (AnimationState anim in _body.animation) {
			//			Debug.Log(anim.name);
			_animList.Add(anim);
		}
		
		//		_animList = _body.GetComponent("Animations") as Animation[];
		//		_animList = _body. 
		_goal = GameObject.Find("Goal");
		_agent = GetComponent<NavMeshAgent>();
		
		_body.animation.wrapMode = WrapMode.Loop;
		_body.animation.Play("run");
	}
	
	// Update is called once per frame
	void Update () {
		if (_isAlive && !_scouted)
			_agent.SetDestination(_goal.transform.position);
	}
	
	void OnCollisionEnter (Collision col) {
		if ( col.gameObject.tag.IndexOf(GameConfig.BULLET_CODE) >= 0 && _isAlive )
		{
			_isAlive = false;
			_agent.Stop();
			Debug.Log("fuck!!");
			_body.animation.wrapMode = WrapMode.Default;
			
			StartCoroutine("death");
		}
	}

	public void receiveScout()
	{
		_scouted = true;
		_agent.Stop();
		_body.animation.wrapMode = WrapMode.Default;
	}
	
	private IEnumerator death() {
		
		_body.animation.Play("death");
		
		yield return new WaitForSeconds (1.8f);
		
		Destroy(gameObject);
	}
}
