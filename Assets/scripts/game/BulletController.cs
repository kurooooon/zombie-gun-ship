using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

	private BulletFactory _bulletFactory;
	private BaseBulletData _bullet;
	
	private Camera _camera;

	void Awake () {
		_camera = Camera.main;
		_bulletFactory = GameObject.Find("BulletFactory").GetComponent<BulletFactory>();
		setBullet(GameConfig.BULLET_BOMB);
	}

	public float getScope
	{
		get{ return _bullet.scope; }
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setBullet(string bulletCode)
	{
		_bullet = _bulletFactory.createBullet(bulletCode);
		_bullet.init();
		GameData.bulletData = _bullet;
	}

	public void shoot(Vector3 pos)
	{
		if (_bullet.isReload) return;

		Ray ray = _camera.ScreenPointToRay(pos);
		GameObject bullet = Instantiate(_bullet.pf, _camera.transform.position, _camera.transform.rotation) as GameObject;
		Vector3 dir = ray.direction.normalized;
		bullet.rigidbody.velocity = dir * _bullet.speed;
		_bullet.slot = _bullet.slot - 1;
		Debug.Log("shoot current " + _bullet.slot);

		if (_bullet.slot <= 0)
		{
			Debug.Log("reload start");
			_bullet.reload();
		}
	}
}
