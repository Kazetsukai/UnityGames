using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

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
		Destroy(gameObject);
	}
}
