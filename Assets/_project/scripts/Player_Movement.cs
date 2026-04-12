using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5f;

    private Vector3 move = Vector3.zero;
    void Start()
    {
        if (!rb)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (tag != "Player") return;

        

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            move.x -= 1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            move.x += 1f;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            move.z -= 1f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            move.z += 1f;

        move = move.normalized * speed;

        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        
    }
}