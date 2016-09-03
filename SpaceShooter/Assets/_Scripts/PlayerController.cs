using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public float speed=10.0f;
    public float tilt = 4.0f;
    public Boundary boundary;

    public GameObject shotBolt;
    public Transform shotPoint;

	void Start () {
	}

    void ShotBolt()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GameObject.Instantiate(shotBolt, shotPoint.position, shotPoint.rotation);
        }
    }

	void Update () {
        ShotBolt();
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb)
        {
            rb.velocity = movement * speed;
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.yMin, boundary.yMax)
                );
        }
    }

}
