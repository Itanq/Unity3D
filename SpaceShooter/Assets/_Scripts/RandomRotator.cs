using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumple = 10.0f;
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumple;
	}
	
}
