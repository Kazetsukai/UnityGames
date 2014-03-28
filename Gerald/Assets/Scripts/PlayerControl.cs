using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerControl : MonoBehaviour {

    public GameObject ExplosionEffect;
	Vector3 _targetPos;
	float maxSpeed = 20;

	// Use this for initialization
	void Start () {
		_targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_targetPos = new Vector3(pos.x, pos.y + 1.3f);
		
		if (transform.position != _targetPos)
		{
			var maxSpeedOneFrame = maxSpeed * Time.fixedDeltaTime;
			var diff = (_targetPos - transform.position);
			var length = diff.magnitude;
			if (length > maxSpeedOneFrame)
			{
				diff.Normalize();
				diff.Scale(new Vector3(maxSpeedOneFrame, maxSpeedOneFrame));
			}
			transform.position += diff;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.GetComponents<MonoBehaviour>().Any(c => c is ICollidableEnemy))
        {
            var explosion = (GameObject)Instantiate(ExplosionEffect);
            explosion.transform.position = transform.position;
            explosion.rigidbody2D.AddForce(rigidbody2D.velocity * 10);
            Destroy(gameObject);
        }
	}
}
