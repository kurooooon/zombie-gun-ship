using UnityEngine;
using System.Collections;

public class HumanFactory : MonoBehaviour {

	public GameObject humanPF;

	private float _timer;
	private GameObject _factory;
	
	// Use this for initialization
	void Start ()
	{
		_factory = transform.FindChild("InitPos").gameObject;
		_timer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		float rand = Random.value;
//		if (rand > 0.997f)
//		{
////			Debug.Log("generate human");
////			float num = Random.Range(1, 3);
////			for (int i = 0; i < num; i++)
////			{
//			GameObject human = Instantiate(humanPF, _factory.transform.position, transform.rotation) as GameObject;
////			}
//		}

		_timer += Time.deltaTime;
		
		if (_timer >= 3.0f)
		{
			_timer = 0.0f;
			float rand = Random.value;
			if (rand > 0.9f)
			{

				create();
			}
		}
	}

	private void create()
	{
		GameObject human = Instantiate(humanPF, _factory.transform.position, transform.rotation) as GameObject;
	}
}
