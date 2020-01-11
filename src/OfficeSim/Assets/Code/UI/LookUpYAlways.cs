using UnityEngine;

public class LookUpYAlways : MonoBehaviour
{
    void Update() 
    { 
        transform.LookAt(new Vector3(transform.position.x, -100, transform.position.z));
    }
}
