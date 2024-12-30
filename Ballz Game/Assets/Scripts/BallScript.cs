using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed,
            Space.World);
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            FindObjectOfType<GameManagerScript>().EndLife();
        }
    }

    public void HitBall()
    {
        GameManagerScript.score++;
        Debug.Log(GameManagerScript.score);
        Destroy(gameObject);
    }
}
