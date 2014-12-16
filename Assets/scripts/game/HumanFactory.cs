using UnityEngine;
using System.Collections;

public class HumanFactory : MonoBehaviour {

	public GameObject humanPF;
	
	private GameObject _factory;
	
	// Use this for initialization
	void Start () {
		_factory = transform.FindChild("InitPos").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		float rand = Random.value;
		if (rand > 0.997f)
		{
//			Debug.Log("generate human");
			float num = Random.Range(1, 3);
			for (int i = 0; i < num; i++)
			{
				GameObject human = Instantiate(humanPF, _factory.transform.position, transform.rotation) as GameObject;
			}
		}
	}
}
