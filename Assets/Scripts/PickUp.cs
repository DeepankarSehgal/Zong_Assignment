using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdPoint; // Set this to the point where the object will be held.
    private GameObject heldObject;

    void Update()
    {
        if (heldObject != null && Input.GetKeyDown(KeyCode.Space)) // Press space to drop the object
        {
            heldObject.GetComponent<Rigidbody>().useGravity = true;
            heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            heldObject.transform.parent = null;
            heldObject.GetComponent<BoxCollider>().enabled = true;
            heldObject = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (heldObject == null && other.gameObject.CompareTag("Sphere")) // Ensure the object has the "Pickup" tag
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                heldObject = other.gameObject;
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation; // Freeze position and rotation
                heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                heldObject.transform.position = holdPoint.position;
                heldObject.transform.parent = holdPoint;
                heldObject.GetComponent<BoxCollider>().enabled = false;
            }

        }
    }
}
