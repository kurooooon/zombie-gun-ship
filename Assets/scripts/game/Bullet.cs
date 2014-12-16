using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject effectPF;

	// Use this for initialization
	void Start () {
	}
	 
	// Update is called once per frame
	void Update () {
	}

	void OnBecameInvisible () {
		Destroy(gameObject);
	}
	
	void OnCollisionEnter(Collision col) {
//		gameObject.renderer.enabled = false;
		Destroy(gameObject);
		Instantiate(effectPF, transform.position, transform.rotation);
	}

//	private IEnumerator bomb() {
//		
//
////		Destroy(gameObject);
//
//		yield return 0;//new WaitForSeconds (0.1f);
//
//		Destroy(effectPF);
//	}
}
