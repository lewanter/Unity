using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{

    public float carSpeed = 4;
    Vector3 position;
    private float xMin;
    private float xMax;

    // Use this for initialization
    void Start()
    {
        position = new Vector3(GetComponent<Renderer>().transform.position.x, GetComponent<Renderer>().transform.position.y);
        xMin = -1.4f;
        xMax = 1.4f;
    }

    // Update is called once per frame
    void Update()
    {

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        if (position.x < xMin)
        {
            position.x = xMin;
        }
        else if (position.x > xMax)
        {
            position.x = xMax;
        }

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
        }
    }
}
