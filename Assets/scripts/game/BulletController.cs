using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

//	public GameObject bombPF;
//	public BombData bombData;
//	public GameObject riflePF;
//	public RifleData rifleData;

	private BulletFactory _bulletFactory;
	private BaseBulletData _bullet;
	
	private Camera _camera;

//	private const int BULLET_POWER = 50;
//	private const int BULLET_POWER = 100;

	void Awake () {
		_camera = Camera.main;
//		bombData = GetComponent<BombData>();
		_bulletFactory = GameObject.Find("BulletFactory").GetComponent<BulletFactory>();
//		_bullet = bombData;
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
//		if ( Input.GetMouseButtonDown(0) )//Input.touchCount > 0 )
//		{
//
////			Touch touch = Input.GetTouch(0);
//			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
////			Vector3 worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
//			GameObject bullet = Instantiate(bulletPF, _camera.transform.position, _camera.transform.rotation) as GameObject;
//			Vector3 dir = ray.direction.normalized;
//			bullet.rigidbody.velocity = dir * BULLET_POWER;
//		}
	}

	public void setBullet(string bulletCode)
	{
		_bullet = _bulletFactory.createBullet(bulletCode);
//		_bullet = _bulletPF.GetComponent<BaseBulletData>();
		_bullet.init();
	}

	public void shoot(Vector3 pos)
	{
//		if (bombData.isReload) return;
		if (_bullet.isReload) return;

//		Touch touch = Input.GetTouch(0);
		Ray ray = _camera.ScreenPointToRay(pos);
//		Vector3 worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
//		GameObject bullet = Instantiate(bombPF, _camera.transform.position, _camera.transform.rotation) as GameObject;
		GameObject bullet = Instantiate(_bullet.pf, _camera.transform.position, _camera.transform.rotation) as GameObject;
		Vector3 dir = ray.direction.normalized;
//		bullet.rigidbody.velocity = dir * bombData.speed;
		bullet.rigidbody.velocity = dir * _bullet.speed;
		_bullet.slot = _bullet.slot - 1;
		Debug.Log("shoot current " + _bullet.slot);

		if (_bullet.slot <= 0)
		{
			Debug.Log("reload start");
			_bullet.reload();
//			return;
		}
	}
}
