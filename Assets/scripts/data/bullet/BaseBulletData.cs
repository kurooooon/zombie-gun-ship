using UnityEngine;
using System.Collections;

public class BaseBulletData : MonoBehaviour
{ 
	protected GameObject _pf;
	protected float _timer;
	protected int _speed;
	protected float _scopeScale;
	protected int _slot;
	protected float _reloadTime;
	protected bool _isReload; 

	public BaseBulletData ()
	{
	}

	virtual public void init()
	{
		_isReload = false;
	}

	public GameObject pf
	{
		get { return _pf; }
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

	public float scope
	{
		get { return _scopeScale; }
	}
	
	virtual public bool isReload
	{
		get { return _isReload; }
		set { _isReload = value; }
	}
	
	virtual public void reload()
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
				Debug.Log("reload end");
			}
		}
	}
}