using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public GameObject shotBolt;
    public Transform shotPoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Shot", 1.0f, 0.5f);
	}
	
    void Shot()
    {
        GetComponent<AudioSource>().Play();
        GameObject.Instantiate(shotBolt, shotPoint.position, shotPoint.rotation);
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
