using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour, ICollidableEnemy, ITriggerEnter2D {

	public Vector2 Acceleration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce(Acceleration);
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag.Contains("PlayerBullet"))
		{
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
