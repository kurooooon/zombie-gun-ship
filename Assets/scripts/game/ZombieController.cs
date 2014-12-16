 using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	private GameObject _body;
	private GameObject _goal;
	private NavMeshAgent _agent;
	private ArrayList _animList; 
	private bool _isAlive;
	private bool _scouting;
	private bool _attacking;
	private GameObject _targetHuman;
	private float _timer;

	// Use this for initialization
	void Start () {
		_isAlive = true;
		_scouting = false;
		_attacking = false;

		_body = gameObject.transform.FindChild("ZombieBody").gameObject; 
		_animList = new ArrayList(); 
		foreach (AnimationState anim in _body.animation) {
//			Debug.Log(anim.name);
			_animList.Add(anim);
		}

		_goal = GameObject.Find("Goal");
		_agent = GetComponent<NavMeshAgent>();
		startRun();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_attacking)
		{
			attackTimer();
			return;
		}

		if (_scouting && _targetHuman)
		{
			_agent.SetDestination(_targetHuman.transform.position);
		}
		else if (_isAlive)
		{
			_agent.SetDestination(_goal.transform.position);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		//bullet
		if ( col.gameObject.tag.IndexOf(GameConfig.BULLET_CODE) >= 0 && _isAlive )
		{
			_isAlive = false;
			_agent.Stop();
			Debug.Log("fuck!!");
			_body.animation.wrapMode = WrapMode.Default;

			StartCoroutine("death");
		}
//		else if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN) >= 0 && !_scouting)
//		{
//			Debug.Log("scout target");
//			_scouting = true;
//			_targetHuman = col.gameObject;
//		}
	}

	void OnTriggerEnter(Collider col)
	{
		//human
		if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN) >= 0)
		{
			_attacking = true;
			Debug.Log("attack zombie -> human");
			HumanController humanController = col.gameObject.GetComponent<HumanController>(); 
			humanController.receiveScout(gameObject);
			_agent.Stop();
			_body.animation.Play("idle");
			_body.animation.wrapMode = WrapMode.Default;
			startAttack();
		}
	}

	public void findTarget(GameObject target)
	{
		if (!_scouting)
		{
			_scouting = true;
			_targetHuman = target;
			transform.LookAt(_targetHuman.transform);
		}
	}

	private IEnumerator death() {

		_body.animation.Play("death");

		yield return new WaitForSeconds (1.8f);
		
		Destroy(gameObject);
	}

	private void startRun()
	{
		_body.animation.wrapMode = WrapMode.Loop;
		_body.animation.Play("run");
	}
	
	private void startAttack()
	{
		_timer = 0f;
	}

	private void attackTimer()
	{
		if (!_targetHuman)
		{
			_attacking = false;
			startRun();
			return;
		}

		_timer += Time.deltaTime;

		if (_timer >= 2.5f)
		{
			_timer = 0.0f;
			if (_targetHuman)
			{
				StartCoroutine("attack");
			}
		}
	}

	private IEnumerator attack()
	{
		_body.animation.Play("attack01");
		yield return new WaitForSeconds(0.5f);
		_targetHuman.GetComponent<HumanController>().attacked();
	}
}
