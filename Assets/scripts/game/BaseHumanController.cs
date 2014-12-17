using UnityEngine;
using System.Collections;

/// <summary>
/// Base human controller.
/// </summary>
public class BaseHumanController : MonoBehaviour
{
	protected ArrayList _animList; 
	protected GameController _controller;
	protected NavMeshAgent _agent;
	protected GameObject _body;
	protected GameObject _goal;

	public BaseHumanController ()
	{
	}

	virtual protected void Start()
	{
		_controller = GameObject.Find(GameConfig.GAME_CONTROLLER).GetComponent<GameController>();
		_goal = GameObject.Find("Goal");
		_agent = GetComponent<NavMeshAgent>();
		getAnimList();
	}
	
	protected bool isGoal
	{
		get { return ( Vector3.Distance(transform.position, _goal.transform.position) < 1f ); }
	}

	protected void getAnimList()
	{
		_animList = new ArrayList(); 
		foreach (AnimationState anim in _body.animation) {
//			Debug.Log(anim.name);
			_animList.Add(anim);
		}
	}

	virtual protected void enterGoal()
	{
	}

	virtual protected void startRun()
	{
		_body.animation.wrapMode = WrapMode.Loop;
		_body.animation.Play("run");
	}
}
