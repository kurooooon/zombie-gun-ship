using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject bulletPF;
	
	private Camera _camera;

	private const int BULLET_POWER = 50;

	void Awake () {
		_camera = Camera.main;
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

	public void shoot(Vector3 pos)
	{
//		Touch touch = Input.GetTouch(0);
		Ray ray = _camera.ScreenPointToRay(pos);
//		Vector3 worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
		GameObject bullet = Instantiate(bulletPF, _camera.transform.position, _camera.transform.rotation) as GameObject;
		Vector3 dir = ray.direction.normalized;
		bullet.rigidbody.velocity = dir * BULLET_POWER;
	}
}
