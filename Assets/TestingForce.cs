using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 200);
        GetComponent<Rigidbody>().AddTorque(transform.forward * 200);
    }
    
}
