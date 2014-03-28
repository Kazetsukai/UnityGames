using UnityEngine;
using System.Collections;

public class ConstantShooting : MonoBehaviour {

	float reload = 0;
	float timeToReload = 0.35f;

	public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        reload -= Time.fixedDeltaTime;
        if (reload < 0)
            reload = 0;

		if (Input.GetMouseButton(0))
		{
			if (reload <= 0)
			{
				reload = timeToReload;
				var bullet1 = (GameObject)Instantiate(Bullet);
				var bullet2 = (GameObject)Instantiate(Bullet);
				
				bullet1.transform.position = transform.position + new Vector3(-0.2f, 0.2f, 0);
				bullet2.transform.position = transform.position + new Vector3(0.2f, 0.2f, 0);
				
				bullet1.rigidbody2D.AddForce(Vector2.up * 700);
				bullet2.rigidbody2D.AddForce(Vector2.up * 700);
			}
		}
	}
}
