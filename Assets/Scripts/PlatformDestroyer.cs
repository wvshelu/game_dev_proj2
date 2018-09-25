using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
    /*
    private Transform deletePoint;

	void Awake () {
        deletePoint = GameObject.Find("Bottom Delete Point").transform;

        //if this platform is below the y of the delete point, run DestroyPlatform()
        if (gameObject.transform.position.y < deletePoint.position.y)
        {
            DestroyPlatform();
        }
    } */

    void Update()
    {
        Vector3 v = Camera.main.WorldToViewportPoint(transform.position);
        if (v.y < -0.1) {
            DestroyPlatform();
        }
    }



    private void DestroyPlatform()
    {
        //remove a platform from the platformCount in the Script gameobject
        PlatformGenerator.Singleton().platformCount--;
        //destroy the platform this script is attached to
        Destroy(gameObject);
    }
}
