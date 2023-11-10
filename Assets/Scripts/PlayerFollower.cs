using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private GameObject pov;

    void LateUpdate()
    {
        transform.position = pov.transform.position;
        transform.rotation = pov.transform.rotation;
    }
}
