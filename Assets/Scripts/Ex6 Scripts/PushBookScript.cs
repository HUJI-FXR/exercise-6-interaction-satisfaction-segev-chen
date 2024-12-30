using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBookScript : MonoBehaviour
{
    [SerializeField] private GameObject bookFalling;
    [SerializeField] private float pushForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushBook()
    {
        if (bookFalling == null)
        {
            Debug.LogError("Book Transform is not assigned.");
            return;
        }

        Rigidbody rb = bookFalling.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on the assigned book.");
            return;
        }

        // Remove the constraint on the book's x-axis rotation
        rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        Vector3 pushDirection = new Vector3(1, 0, 0);  // Push along the x-axis
        rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
    }

}
