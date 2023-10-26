using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float boundaryToDespawn;
    public float uniqueStartHeight;
    public float uniqueStartX;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(uniqueStartX, uniqueStartHeight);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = speed * Time.deltaTime;
        transform.position += new Vector3(horizontalSpeed, 0, 0);

        if (transform.position.x < boundaryToDespawn)
        {
            Destroy(gameObject);
        }
    }
}
