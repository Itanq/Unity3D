using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed = 20.0f;

	void Start () {
        // 一生成此物体即往世界坐标系的前方移动
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
	}
}
