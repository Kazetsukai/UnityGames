using UnityEngine;
using System.Collections;

public class DestroyParticleOnComplete : MonoBehaviour {
	void Update () {
		if (particleSystem.isStopped || particleSystem.isPaused)
			Destroy (gameObject);
	}
}
