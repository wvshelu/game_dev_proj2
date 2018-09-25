using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompleteCameraController : MonoBehaviour
{

    //private PlayerScript player;       //Public variable to store a reference to the player game object
    //private Vector3 targetPosition;
    private float totalHeight;
    private static CompleteCameraController controller;
    private int changes;
    private int numGen;
    public Text scoreText;
    public static int score;
    // private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
        //player = PlayerScript.Singleton();
        //targetPosition = transform.position;
        totalHeight = 0;
        changes = 0;
        controller = this;
        numGen = Random.Range(2, 5) * 10;
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
        //float y = player.GetChange();
        if (totalHeight > 0) {
            //targetPosition = transform.position + new Vector3(0, y, 0);
            transform.Translate(new Vector3(0, 0.05f, 0));

            if (changes % numGen == 0) {
                GameObject.Find("Scripts").GetComponent<PlatformGenerator>().SpawnPlatform();
                numGen = Random.Range(4, 6) * 10;
            }
            totalHeight -= 0.05f;
            changes += 1;

        }
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 2);
        //transform.Translate();
    }

    public void AddHeight(float height) {
        if (height > 0) {
            controller.totalHeight += height;
            score += (int)height;
            scoreText.text = "Score: " + score;
        }
            
    }

    public static CompleteCameraController GetSingleton() {
        return controller;
    }
}