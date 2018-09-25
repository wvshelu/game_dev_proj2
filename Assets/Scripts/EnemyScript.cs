using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject particles;
    private float xNeg, xPos;
    private bool increment;
	// Use this for initialization
	void Start () {
        xNeg = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 0)).x;
        xPos = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 0)).x;
        if (transform.position.x - xNeg < xPos - transform.position.x)
            increment = true;
        else
            increment = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (increment) {
            if (transform.position.x < xPos)
                transform.Translate(new Vector3(0.05f, 0, 0));
            else
                increment = false;
        } else {
            if (transform.position.x > xNeg)
                transform.Translate(new Vector3(-0.05f, 0, 0));
            else
                increment = true;
        }
	}

    public void Die() {
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
