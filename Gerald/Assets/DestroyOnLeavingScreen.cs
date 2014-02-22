using UnityEngine;
using System.Collections;

public class DestroyOnLeavingScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -4) Destroy(gameObject);
		if (transform.position.x > 4) Destroy(gameObject);
		if (transform.position.y < -6) Destroy(gameObject);
		if (transform.position.y > 6) Destroy(gameObject);
	}
}
