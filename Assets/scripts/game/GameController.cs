using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private Camera _camera;
	private BulletController _bulletController;

	private Vector3 _startPos;
	private bool _isZoom;
	private bool _isDraging;
	private float _defaultScale;
	
	void Start ()
	{
		GameData.killZombie = 0;
		GameData.life = 3;
		GameData.getMoney = 0;
		_camera = Camera.main;
		_defaultScale = _camera.fieldOfView;
		_bulletController = GameObject.Find(GameConfig.BULLET_CONTROLLER).GetComponent<BulletController>();
		_isZoom = false;
		_isDraging = false;
	}

	void Update ()
	{

//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			toZoom();
//		}

		if ( Input.GetMouseButtonDown(0) )
		{
			_startPos = Input.mousePosition;
		}
		else if ( Input.GetMouseButton(0) )
		{
			if (_startPos != Input.mousePosition)
			{
				_isDraging = true;
				float distX = Input.mousePosition.x - _startPos.x;
				float distY = Input.mousePosition.y - _startPos.y;
				_camera.transform.Rotate( new Vector3(distY / 500, -distX / 500, 0) );
			}
		}
		else if ( Input.GetMouseButtonUp(0) )
		{
			if (_isDraging)
				_isDraging = false;
			else
				_bulletController.shoot(_startPos);
		}

	}

	public void setZoom(string code)
	{
		float scope = _bulletController.getScope;
		if (code == GameConfig.ZOOM_IN && !_isZoom)
		{
			_isZoom = true;
			_camera.fieldOfView = _camera.fieldOfView / scope;//_bulletController.getScope;
		}
		else
		{
			_isZoom = false;
			_camera.fieldOfView = _defaultScale;
		}
//		toZoom();
	}
	
//	private void toZoom ()
//	{
//		float zoom = (_isZoom) ? _camera.fieldOfView * 2 : _camera.fieldOfView / 2;
//		_camera.fieldOfView = zoom;
//		_isZoom = !_isZoom;
//	}

	public void getMoney(int count)
	{
		GameData.getMoney = GameData.getMoney + count;
		Debug.Log("get money total:" + GameData.getMoney);
	}

	public void killZombie()
	{
		GameData.killZombie = GameData.killZombie + 1;
		Debug.Log("kill total:" + GameData.killZombie);
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

	public void setBullet(string bulletCode)
	{
		setZoom(GameConfig.ZOOM_OUT);
		_bulletController.setBullet(bulletCode);
	}

	private void gameOver()
	{
		SceneManager.instance.changeScene(SceneData.SCORE_SCENE, 0.5f);
	}
}
