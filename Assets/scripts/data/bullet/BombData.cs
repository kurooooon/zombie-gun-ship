using UnityEngine;
using System.Collections;

public class BombData : BaseBulletData
{
	private const int MAX_SLOT = 4;
	private const float RELOAD_TIME = 2f;

	public BombData()
	{
		_speed = 150;
		_scopeScale = 2;
		_slot = MAX_SLOT;
		_reloadTime = RELOAD_TIME;
	}

	public int speed
	{
		get { return _speed; }
	}

	public int slot
	{
		get { return _slot; }
		set { _slot = value; }
	}

	public bool isReload
	{
		get { return _isReload; }
		set { _isReload = value; }
	}

	public void reload()
	{
		_timer = 0;
		_isReload = true;
	}

	override protected void endReload()
	{
		_slot = MAX_SLOT;
	}
}
