using UnityEngine;
using System.Collections;

public class BoundaryDestroy : MonoBehaviour {

    // 超出边界外自动销毁
    void OnTriggerExit(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
