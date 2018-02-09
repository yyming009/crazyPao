using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Capsule(Clone)")
        {
            transform.Rotate(3, 0, 0);
        }

        if (gameObject.name == "coin(Clone)")
        {
            transform.Rotate(0, 0, 3);
        }
    }
}
