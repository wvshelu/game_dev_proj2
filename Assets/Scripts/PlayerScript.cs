using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    public static bool gameOver;
    public GameObject particles;


    Rigidbody2D playerBody;
    int update;
    //static PlayerScript ps;
    //float yDiff;
    float prevY;
    //bool changed, hit;
    // Use this for initialization
    void Awake () {
        playerBody = GetComponent<Rigidbody2D>();
        update = 0;
       // ps = this;
       // yDiff = 0;
        prevY = 0;
        // changed = false;
        // hit = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (update > 10) {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerBody.AddForce(new Vector2(50, 0));
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerBody.AddForce(new Vector2(-50, 0));
            }
            update = 0;
        } else {
            update++;
        }

        if (playerBody.transform.position.y <= -10) {
            gameOver = true;
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("floor") && playerBody.velocity.y <= 0) {
            playerBody.AddForce(new Vector2(0, 400));
            CompleteCameraController.GetSingleton().AddHeight(coll.transform.position.y - prevY);
            prevY = coll.transform.position.y;
            EnemyScript enemyScript = coll.gameObject.GetComponentInParent<EnemyScript>();
            if (enemyScript != null) {
                enemyScript.Die();
            }
        } else if (coll.gameObject.tag.Equals("gameover")) {
            Die();
        }
    }
    /*
    public float GetChange() {

        if (changed) {
            changed = false;
            return yDiff;
        }
        return 0;
    } **/

    void Die()
    {
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        gameOver = true;
        Destroy(gameObject);
    }


    /*
    public static PlayerScript Singleton() {
        return ps;
    } */
}
