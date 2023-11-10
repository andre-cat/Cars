using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;

    [SerializeField] private string id;

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal" + id);
        float verticalInput = Input.GetAxis("Vertical" + id);

        transform.Translate(Vector3.forward * verticalInput * forwardSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
