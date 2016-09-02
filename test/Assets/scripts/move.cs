using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
        }
    }
}
