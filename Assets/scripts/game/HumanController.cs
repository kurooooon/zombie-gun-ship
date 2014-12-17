using UnityEngine;
using System.Collections;

public class HumanController : BaseHumanController
{	
//	public GameObject humanDetactionPF;
//	private GameObject _humanDetactionGO;
	private bool _isAlive;
//	private bool _scouted;
	private int _life;
	private GameObject _scoutedZombie;

	void Start ()
	{
		_isAlive = true;
//		_scouted = false;
		_life = GameConfig.HUMAN_LIFE;

		_body = gameObject.transform.FindChild("MAX").gameObject;
		base.Start();

//		startRun();
	}

	void Update ()
	{
		if (_isAlive && !_scoutedZombie)
		{
			if (!_agent.hasPath)
			{
				if (isGoal)
				{
					enterGoal();
					return;
				}

//				setDetection();
				_agent.SetDestination(_goal.transform.position);
				startRun();
			}
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if ( col.gameObject.tag.IndexOf(GameConfig.BULLET_CODE) >= 0 && _isAlive )
		{
			receiveBullet();
		}
	}

	void OnTriggerEnter(Collider col)
	{
	}

	private void receiveBullet()
	{
		_isAlive = false;
		_agent.Stop();
		_agent.ResetPath();
//		Debug.Log("fuck!!");
		_body.animation.wrapMode = WrapMode.Default;
		
		StartCoroutine("death");
	}

	public void receiveScout(GameObject zombie)
	{
		_scoutedZombie = zombie;
//		_scouted = true;
		_agent.Stop();
		_agent.ResetPath();
		transform.LookAt(zombie.transform);
		_body.animation.Play("idle");
		_body.animation.wrapMode = WrapMode.Default;
	}

	public void attacked()
	{
		_life--;
		Debug.Log(_life);
		if (_life <= 0)
		{
			StartCoroutine("death");
		}
	}

//	private void setDetection()
//	{
//		_humanDetactionGO = Instantiate(humanDetactionPF, transform.position, transform.rotation) as GameObject;
//		_humanDetactionGO.transform.parent = transform;
//	}
//
//	private void removeDetection()
//	{
//		Destroy(_humanDetactionGO);
//	}
//
//	public void setFindTarget()
//	{
//		Destroy(rigidbody);
////		removeDetection();
//	}
	
	private IEnumerator death() {
		
		_body.animation.Play("death");
		
		yield return new WaitForSeconds (1.8f);
		
		Destroy(gameObject);
		_controller.lostLife();
	}

	override protected void enterGoal()
	{
		_controller.getMoney(5);
		Destroy(gameObject);
	}
}
