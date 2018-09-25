using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    private Transform leftPoint, rightPoint;
    public GameObject platform, player, enemy;
    public int platformCount, maxPlatforms;
    private static PlatformGenerator pg;
    private float leftVal, rightVal;
    private int timeEnemy;

	void Start () {
        leftPoint = GameObject.Find("Leftmost Spawn").transform;
        rightPoint = GameObject.Find("Rightmost Spawn").transform;
        leftVal = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0, 0)).x;
        rightVal = Camera.main.ViewportToWorldPoint(new Vector3(0.8f, 0, 0)).x;
        platformCount = 0;
        maxPlatforms = 6;
        pg = this;
        timeEnemy = Random.Range(4, 8);
	}
	
	
    //destorying platforms is handled by the platforms themselves
    public void SpawnPlatform() {
        if (platformCount <= maxPlatforms)
        {
            platformCount++; //increment the number of platforms present
                             //choose a random x point between left and right to spawn at
            float z = leftPoint.position.z;
            float y = leftPoint.position.y;
            float rx = Random.Range(leftPoint.position.x, rightPoint.position.x);

            Vector3 position = new Vector3(rx, y, z);
            Instantiate(platform, position, Quaternion.identity);
            timeEnemy--;
            if (timeEnemy < 0) {
                Instantiate(enemy, new Vector3(-1 * rx, y, z), Quaternion.identity);
                timeEnemy = Random.Range(4, 8);
            }

        }
    }

    public static PlatformGenerator Singleton() {
        return pg;
    }
}
