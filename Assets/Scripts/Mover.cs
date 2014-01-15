using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        rigidbody.velocity = Vector3.forward * speed;
    }
}
