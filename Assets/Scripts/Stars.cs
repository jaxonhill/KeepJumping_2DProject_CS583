using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public float speed;
    public float boundaryToDespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = speed * Time.deltaTime;
        transform.position += new Vector3(-horizontalSpeed, 0, 0);

        if (transform.position.x < boundaryToDespawn)
        {
            Destroy(gameObject);
        }
    }
}
