using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyScript : MonoBehaviour
{
    public Transform Target;
    public Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
       
    }
}
