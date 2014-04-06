using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour, ICollidableEnemy, ITriggerEnter2D {

	public Vector2 Acceleration;
	public GameObject ExplosionEffect;

    private const float MAX_SPEED = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D.velocity.magnitude < MAX_SPEED)
            rigidbody2D.AddForce(Acceleration);
        else if (rigidbody2D.velocity.magnitude > MAX_SPEED)
        {
            rigidbody2D.velocity.Normalize();
            rigidbody2D.velocity *= (MAX_SPEED);
        }
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag.Contains("PlayerBullet"))
		{
            FindObjectOfType<ScoringBehaviour>().IncrementScore();
			var explosion = (GameObject)Instantiate(ExplosionEffect);
			explosion.transform.position = transform.position;
            explosion.rigidbody2D.AddForce(rigidbody2D.velocity * 10);
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
