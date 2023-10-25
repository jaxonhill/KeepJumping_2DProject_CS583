using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10f;
    public float jumpHeight = 10f;
    public float bouncePadHeight = 10f;
    public float enemyHeadBounceHeight = 10f;
    public GameObject ground;
    public Rigidbody2D rb;
    public TextMeshProUGUI gt;
    public float deathBorderX;
    public AudioSource jumpSource;
    public AudioClip jumpSound;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Get sprite renderer to flip sprite
        sr = GetComponent<SpriteRenderer>();

        // NOTE: Score code is from ApplePicker
        // Get score object and update score
        GameObject scoreGO = GameObject.Find("Score");
        // Find a reference to the ScoreCounter GameObject
        gt = scoreGO.GetComponent<TextMeshProUGUI>();
        // Get the Text Component of that GameObject
        gt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Move horizontal
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(horizontal, 0, 0);

        // Get current flip value
        bool currentFlip = sr.flipX;

        // Flip sprite to left if horizontal is negative
        if (horizontal < 0)
        {
            sr.flipX = true;
        }
        // If horizontal is positive then keep sprite not flipped (facing right)
        else if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else
        {
            // This keeps sprite facing same way as the player left off (horizontal == 0)
            sr.flipX = currentFlip;
        }

        // Check for border
        Vector3 pos = transform.position;
        if (pos.x >= deathBorderX || pos.x <= -deathBorderX)
        {
            SceneManager.LoadScene("_Scene_01");
        }

        // Update score
        // NOTE: Code is from ApplePicker
        // Parse the text of the score into an int
        int score = int.Parse(gt.text);
        // Add points for catching the apple
        score += 1;
        // Convert the score back to a string and display it
        gt.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision of spikes before ground, just based on way collisions work on this game
        if (collision.gameObject.tag == "Spikes")
        {
            // Reset scene, game over
            SceneManager.LoadScene("_Scene_01");
        }
        if (collision.gameObject.tag == "Ground")
        {
            // Play jump sound effect
            jumpSource.PlayOneShot(jumpSound);

            // Prevent bug where players could create extra force by quickly hitting platform
            if (rb.velocity.y >= 0)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }

            // Do something, NOTE: I found ForceMode2D.Impulse through documentation because this wasn't working correctly originally
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
        // Add a lot of force for bounce pad
        if (collision.gameObject.tag == "BouncePad")
        {
            rb.AddForce(new Vector2(0, bouncePadHeight), ForceMode2D.Impulse);
        }
        // Bounce off enemy head
        if (collision.gameObject.tag == "EnemyHead")
        {
            rb.AddForce(new Vector2(0, enemyHeadBounceHeight), ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }
}
