using UnityEngine;
using System.Collections;

public class ConstantShooting : MonoBehaviour {

	float timePassed = 0;

	public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.fixedDeltaTime;
		if (timePassed > 0.1f)
		{
			timePassed -= 0.1f;
			var bullet1 = (GameObject)Instantiate(Bullet);
			var bullet2 = (GameObject)Instantiate(Bullet);
			
			bullet1.transform.position = transform.position + new Vector3(-0.2f, 0.2f, 0);
			bullet2.transform.position = transform.position + new Vector3(0.2f, 0.2f, 0);
		}
	}
}
