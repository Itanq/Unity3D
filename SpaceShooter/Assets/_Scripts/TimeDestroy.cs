using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour {

    public float lifeTime = 2.0f;
	void Start () {
        Destroy(gameObject, lifeTime);      
	}
	
}
