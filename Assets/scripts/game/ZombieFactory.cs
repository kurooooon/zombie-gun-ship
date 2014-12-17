using UnityEngine;
using System.Collections;

public class ZombieFactory : MonoBehaviour {

	public GameObject zombiePF;

	private GameObject _factory;
	private float _timer;

	// Use this for initialization
	void Start () {
		_factory = transform.FindChild("InitPos").gameObject;
		_timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
//		float rand = Random.value;
//		if (rand > 0.997f)
//		{
////			Debug.Log("generate zombie");
//			float num = Random.Range(1, 5);
//			for (int i = 0; i < num; i++)
//			{
//				GameObject zombie = Instantiate(zombiePF, _factory.transform.position, transform.rotation) as GameObject;
//			}
//		}

		_timer += Time.deltaTime;
		
		if (_timer > 2f)
		{
			_timer = 0.0f;
			float rand = Random.value;
			if (rand > 0.85f)
			{
				create();
			}
		}
	}

	private void create()
	{
		GameObject zombie = Instantiate(zombiePF, _factory.transform.position, transform.rotation) as GameObject;
	}
}
