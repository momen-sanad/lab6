using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDmg : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.gameObject.tag == "Player")
        {
            if(Keyboard.current.qKey.isPressed)
                //logic to stop player
                rb.linearVelocity = Vector3.zero;
        }
    }
}