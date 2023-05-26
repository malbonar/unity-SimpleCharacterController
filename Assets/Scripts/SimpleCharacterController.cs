using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    private Rigidbody _rigidBody;

    private void Start() 
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input.GetAxis returns value between 0 and 1
        // We can then use that value to alter the rigidbody position along that axis
        var leftRight = Input.GetAxis("Horizontal") * moveSpeed;
        var forwardBack = Input.GetAxis("Vertical") * moveSpeed;

        _rigidBody.velocity = new Vector3(leftRight, _rigidBody.velocity.y, forwardBack);

        // use the forward prop of the transform to point our character in the right direction
        var facingDirection = _rigidBody.velocity;
        facingDirection.y = 0;
        // don't face towards original direction when stopped
        if (facingDirection.x != 0 || facingDirection.z != 0)
        {
            transform.forward = facingDirection;
        }
    }
}
