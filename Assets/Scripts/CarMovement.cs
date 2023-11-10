using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 1f;

   private Vector3 firstPosition;
   private Quaternion firstRotation;

    private void Awake()
    {
        firstPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        firstRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    private void FixedUpdate()
    {
        transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            transform.SetPositionAndRotation(firstPosition, firstRotation);
        }
    }
}
