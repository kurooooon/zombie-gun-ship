using UnityEngine;
using System.Collections;

public class RifleData : BaseBulletData
{
	public GameObject pf;
	
	private bool _init = false;
	private const float RELOAD_TIME = 0.4f;
	private const int MAX_SLOT = 1;
	
	public RifleData()
	{
//		if (_init) return;
//		
//		base.init();
//		_pf = pf;
//		_speed = 150;
//		_scopeScale = 4;
//		_slot = MAX_SLOT;
//		_reloadTime = RELOAD_TIME;
//		
//		_init = true;
	}
	
	override public void init()
	{
		Debug.Log("bomb init");
		if (_init) return;
		
		base.init();
		_pf = pf;
		_speed = 300;
		_scopeScale = 4;
		_slot = 1;
		_reloadTime = RELOAD_TIME;
		
		_init = true;
		Debug.Log("bomb init comp");
	}
	
	override protected void endReload()
	{
		_slot = MAX_SLOT;
	}
}
