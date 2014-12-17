using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private Camera _camera;
	private BulletController _bulletController;

	private Vector3 _startPos;
	private bool _isZoom;
	private bool _isDraging;

	// Use this for initialization
	void Start () {
		_camera = Camera.main;
		_bulletController = GameObject.Find(GameConfig.BULLET_CONTROLLER).GetComponent<BulletController>();
		_isZoom = false;
		_isDraging = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			toZoom();
		}

		if ( Input.GetMouseButtonDown(0) )
		{
			_startPos = Input.mousePosition;
//			Debug.Log("drag start");
		}
		else if ( Input.GetMouseButton(0) )
		{
			if (_startPos != Input.mousePosition)
			{
				_isDraging = true;
	//			Debug.Log("start pos" + _startPos.x + ", "+ _startPos.y + ", " + _startPos.z);
	//			Debug.Log("drag..." + Input.mousePosition.x + ", "+ Input.mousePosition.y + ", " + Input.mousePosition.z);
				float distX = Input.mousePosition.x - _startPos.x;
				float distY = Input.mousePosition.y - _startPos.y;
//				Debug.Log("dist: " + distX + ", " + distY);
				_camera.transform.Rotate( new Vector3(distY / 500, -distX / 500, 0) );
			}
		}
		else if ( Input.GetMouseButtonUp(0) )
		{
			if (_isDraging)
				_isDraging = false;
			else
				_bulletController.shoot(_startPos);

//			Debug.Log("drag end");
		}

	}

	/// <summary>
	/// Tos the zoom.
	/// </summary>
	private void toZoom ()
	{
		float zoom = (_isZoom) ? _camera.fieldOfView * 2 : _camera.fieldOfView / 2;
		_camera.fieldOfView = zoom;
		_isZoom = !_isZoom;
	}

	public void getMoney(int count)
	{
//		Debug.Log("get money current:" + GameData.getMoney + ", " + count);
		GameData.getMoney = GameData.getMoney + count;
		Debug.Log("get money total:" + GameData.getMoney);
	}

	public void lostLife()
	{
		GameData.life = GameData.life - 1;
		if (GameData.life <= 0)
		{
			gameOver();
		}
		Debug.Log("lost life total:" + GameData.life);
	}

	private void gameOver()
	{
		Debug.Log("gameOver!");
	}
}
