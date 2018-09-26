using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    public static bool gameOver;
    public GameObject particles;
    public Sprite up1, up2, down1, down2;


    Rigidbody2D playerBody;
    SpriteRenderer spr;
    Sprite[] up, down;
    int update;
    //static PlayerScript ps;
    //float yDiff;
    float prevY;
    //bool changed, hit;
    // Use this for initialization
    void Awake () {
        playerBody = GetComponent<Rigidbody2D>();
        update = 0;
        spr = GetComponent<SpriteRenderer>();
        up = new Sprite[] { up1, up2 };
        down = new Sprite[] { down1, down2 };


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
                transform.localScale = new Vector2(0.75f, 0.75f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerBody.AddForce(new Vector2(-50, 0));
                transform.localScale = new Vector2(-0.75f, 0.75f);
            }
            update = 0;
        } else {
            update++;
        }

        if (playerBody.velocity.y < 0) //falling
        {
            spr.sprite = down[Random.Range(0, 1)];
        }
        else //rising
        {
            spr.sprite = up[Random.Range(0, 1)];
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
