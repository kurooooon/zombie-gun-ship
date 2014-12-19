using UnityEngine;
using System.Collections;

public class BulletFactory : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public BaseBulletData createBullet(string bulletCode)
	{
		if (bulletCode == GameConfig.BULLET_BOMB)
			return GetComponent<BombData>();
		else
			return GetComponent<RifleData>();
	}
}
