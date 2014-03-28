using UnityEngine;
using System.Collections;

public class CurvingEnemy : MonoBehaviour {

    bool _goRight;
    const float CURVE_SPEED = 400;
    const float DOWN_SPEED = 300;

	// Use this for initialization
	void Start () {
        _goRight = transform.position.x < 0;
        rigidbody2D.AddForce(new Vector2(_goRight ? CURVE_SPEED : -CURVE_SPEED, -DOWN_SPEED));
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.AddForce(new Vector2(_goRight ? -CURVE_SPEED : CURVE_SPEED, 0) * Time.fixedDeltaTime);
	}
}
