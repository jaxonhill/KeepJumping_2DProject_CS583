using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float timeBetweenSwitch;
    public float bouncePadHeight = 50f;
    public Rigidbody2D rb;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Flip directions (copied from horizontal platform)
        if (timeElapsed > timeBetweenSwitch && rb.velocity.y == 0)
        {
            // Change direction
            speed = speed * -1;

            // Reset time
            timeElapsed = 0f;
        }

        // Move horizontal
        float horizontal = speed * Time.deltaTime;
        transform.position += new Vector3(horizontal, 0, 0);

        // Increment timeElapsed
        timeElapsed += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BouncePad")
        {
            rb.AddForce(new Vector2(0, bouncePadHeight), ForceMode2D.Impulse);
        }
    }
}
