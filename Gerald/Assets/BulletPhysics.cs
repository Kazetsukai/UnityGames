using UnityEngine;
using System.Collections;

public class BulletPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, 10, 0) * Time.fixedDeltaTime;
	}
}
