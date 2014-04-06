using UnityEngine;
using System.Collections;

public class ScoringBehaviour : MonoBehaviour {

    int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = score.ToString();
	}

    public void IncrementScore(int amount = 1)
    {
        score += amount;
    }
}
