using UnityEngine;
using System.Collections;

public class ZombieController : BaseHumanController
{
//	public ZombieScoutingController scoutingPF;
//	private ZombieScoutingController _scoutingController;
	private ArrayList _animList; 
	private bool _isAlive;
	private bool _scouting;
	private bool _attacking;
	private GameObject _targetHuman;
	private float _timer;
	
	void Start ()
	{
		_isAlive = true;
		_scouting = false;
		_attacking = false;

		_body = gameObject.transform.FindChild("ZombieBody").gameObject; 
		base.Start();

		startRun();
//		setScouting();
	}

	void Update ()
	{
		if (_attacking)
		{
			attackTimer();
			return;
		}

//		if (!_agent.hasPath)
//		{
			//reach goal
			if (isGoal)
			{
				enterGoal();
				return;
			}

			if (_scouting && _targetHuman)
			{
				_agent.SetDestination(_targetHuman.transform.position);
			}
			else if (_isAlive)
			{
//				setScouting();
				_agent.SetDestination(_goal.transform.position);
			}
//		}
	}

	void OnCollisionEnter(Collision col)
	{
//		Debug.Log("collision " + col.gameObject.tag);

		//bullet
		if ( col.gameObject.tag.IndexOf(GameConfig.BULLET_CODE) == 0 && _isAlive )
		{
			_scouting = false;
			_targetHuman = null;
			_isAlive = false;
			_agent.Stop();
			_agent.ResetPath();
//			Debug.Log("fuck!!");
			_body.animation.wrapMode = WrapMode.Default;

			StartCoroutine("death");
		}

		else if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN) == 0 && !_attacking)
		{
			_attacking = true;
			Debug.Log("attack zombie -> human");
			HumanController humanController = col.gameObject.GetComponent<HumanController>(); 
			humanController.receiveScout(gameObject);
			_agent.Stop();
			_agent.ResetPath();
			_body.animation.Play("idle");
			_body.animation.wrapMode = WrapMode.Default;
			startAttack();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN) >= 0)
		{
			findTarget(col.gameObject);
		}
		//human
//		if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN_DETECTION) >= 0 && !_scouting)
//		{
//			Debug.Log("scout target");
//			//			_scouting = true;
//			_targetHuman = col.gameObject.transform.parent.gameObject;
//		}
//		if ( col.gameObject.tag.IndexOf(GameConfig.TAG_HUMAN) == 0)
//		{
//			_attacking = true;
//			Debug.Log("attack zombie -> human");
//			HumanController humanController = col.gameObject.GetComponent<HumanController>(); 
//			humanController.receiveScout(gameObject);
//			_agent.Stop();
//			_agent.ResetPath();
//			_body.animation.Play("idle");
//			_body.animation.wrapMode = WrapMode.Default;
//			startAttack();
//		}
	}

	public void findTarget(GameObject target)
	{
		if (!_scouting && _isAlive)
		{
//			removeScouting();
			_scouting = true;
			_targetHuman = target;
			_agent.ResetPath();
//			_targetHuman.GetComponent<HumanController>().setFindTarget();
			transform.LookAt(_targetHuman.transform);
		}
	}
	
//	override protected void startRun()
//	{
//		_body.animation.wrapMode = WrapMode.Loop;
//		_body.animation.Play("run");
//	}

	override protected void enterGoal()
	{
		Debug.Log("reach goal zombie");
		_controller.lostLife();
		Destroy(gameObject);
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

	private IEnumerator death() {
		
		_body.animation.Play("death");
		_controller.getMoney(GameConfig.DEATH_COIN);
		_controller.killZombie();
		
		yield return new WaitForSeconds (1.8f);
		
		Destroy(gameObject);
	}

	private IEnumerator attack()
	{
		_body.animation.Play("attack01");
		yield return new WaitForSeconds(0.5f);
		_targetHuman.GetComponent<HumanController>().attacked();
	}
}
