using UnityEngine;
using System.Collections;

public class BaseBulletData : MonoBehaviour
{ 
	protected float _timer;
	protected int _speed;
	protected float _scopeScale;
	protected int _slot;
	protected float _reloadTime;
	protected bool _isReload; 

	public BaseBulletData ()
	{
		_isReload = false;
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

	virtual protected void endReload()
	{

	}
	
	void Update()
	{
		if (_isReload)
		{
			_timer += Time.deltaTime;
			
			if (_timer >= _reloadTime)
			{
				_isReload = false;
				endReload();
			}
		}
	}
}