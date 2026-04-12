using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    // goal object rigidbody
    [SerializeField]
    private SphereCollider rb;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something has entered the goal trigger! it was:", other);
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        Debug.Log("Player has reached the goal!");
    }
}
