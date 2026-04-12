using UnityEngine;

public class HazardSelfDestruct : MonoBehaviour
{
    
    void Start() => Destroy(gameObject, 5f);
}
