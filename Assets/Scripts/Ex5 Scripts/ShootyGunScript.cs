using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootyGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletLifetime = 3f;
    [SerializeField] private string floorTag = "Floor";
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private InputActionReference buttonAction;


    // Start is called before the first frame update
    void Start()
    {
        buttonAction.action.started += OnButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse button release
        
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        //Debug.Log("Button Pressed Successfully");
        Shoot(); // Preform the action
    }

    void Shoot()
    {

        Transform cameraTransform = Camera.main.transform;
        GameObject newBullet = Instantiate(bulletPrefab, cameraTransform.position, cameraTransform.rotation);
        newBullet.SetActive(true);

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.velocity = cameraTransform.forward * bulletSpeed;

        Destroy(newBullet, bulletLifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == enemyTag
        || collision.gameObject.tag == floorTag)
        {
            Destroy(gameObject);
        }
    }
}
