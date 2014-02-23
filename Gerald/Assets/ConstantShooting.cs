using UnityEngine;
using System.Collections;

public class ConstantShooting : MonoBehaviour {

	float timePassed = 0;
	float timeToShoot = 0.2f;

	public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			timePassed += Time.fixedDeltaTime;
			if (timePassed > timeToShoot)
			{
				timePassed -= timeToShoot;
				var bullet1 = (GameObject)Instantiate(Bullet);
				var bullet2 = (GameObject)Instantiate(Bullet);
				
				bullet1.transform.position = transform.position + new Vector3(-0.2f, 0.2f, 0);
				bullet2.transform.position = transform.position + new Vector3(0.2f, 0.2f, 0);
				
				bullet1.rigidbody2D.AddForce(Vector2.up * 700);
				bullet2.rigidbody2D.AddForce(Vector2.up * 700);
			}
		}
		else 
			timePassed = timeToShoot;
	}
}
