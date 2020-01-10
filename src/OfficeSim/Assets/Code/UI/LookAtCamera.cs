using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void Update() 
    { 
        //transform.position = gameObject.transform.parent.position + Vector3.up;
        transform.LookAt(new Vector3(transform.position.x, -100, transform.position.z));
    }

}
