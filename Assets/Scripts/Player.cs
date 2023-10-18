using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int playerScore;

    public float jumpForce;

    private Animation thisAnimation;

    private Rigidbody playerRb;

    public Text scoreText;

    void Start()
    {
        playerScore = 0;
        playerRb = GetComponent<Rigidbody>();

        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (transform.position.y > 4 || transform.position.y < -4)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector3(0, jumpForce, 0);
            thisAnimation.Play();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle")) 
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObstacleScoreAdd"))
        {
            playerScore += 10;
            scoreText.text = "SCORE : " + playerScore;
        }
    }
}
