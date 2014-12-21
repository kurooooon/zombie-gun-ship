using UnityEngine;
using System.Collections;

public class BombData : BaseBulletData
{
	public GameObject pf;

	private bool _init = false;
	private const int MAX_SLOT = 2;
	private const float RELOAD_TIME = 2.5f;

	public BombData()
	{
//		Debug.Log("bomb init");
//		if (_init) return;
//		
//		base.init();
//		_pf = pf;
//		_speed = 100;
//		_scopeScale = 2;
//		_slot = MAX_SLOT;
//		_reloadTime = RELOAD_TIME;
//		
//		_init = true;
//		Debug.Log("bomb init comp");
	}

	override public void init()
	{
		Debug.Log("bomb init");
		if (_init) return;

		base.init();
		_pf = pf;
		_speed = 100;
		_scopeScale = 2;
		_slot = MAX_SLOT;
		_reloadTime = RELOAD_TIME;

		_init = true;
		Debug.Log("bomb init comp");
	}

	override protected void endReload()
	{
		_slot = MAX_SLOT;
	}
}
