using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour, ICollidableEnemy {

	public Vector2 Acceleration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce(Acceleration);
	}
}
