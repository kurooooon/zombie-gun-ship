using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

//	private Vector3 _initPos;
//	private Quaternion _initRot;

//	private GameObject _floor;
//	public float _radius = 15.0f;	// オブジェクトからカメラまでの距離(円運動の半径)
//	public float _angle = 0.0f;	// ラジアン値

	// Use this for initialization
	void Start () {
//		_initPos = transform.position;
//		_initRot = transform.rotation;
//		_floor = GameObject.Find("Floor");

//		Vector3 pos = _floor.transform.position;
//		transform.LookAt(pos);
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 offset = new Vector3 ( Mathf.Sin(Time.time), 0, 0 );
//		transform.Translate( new Vector3(_initPos.x + offset.x, 0, 0) );
//		Vector3 pos = _floor.transform.position;
//		transform.LookAt(pos);
//
//		transform.position = new Vector3(Mathf.Cos(_angle) * 10, _initPos.y, Mathf.Sin(_angle) * 10);
//		_angle += 0.005f;

		transform.Rotate(0, 0.2f, 0);
	}
}
 