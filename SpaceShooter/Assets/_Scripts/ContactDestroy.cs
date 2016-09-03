using UnityEngine;
using System.Collections;

public class ContactDestroy : MonoBehaviour {

    public GameObject explosion; // 小行星爆炸
    public GameObject playerExplosion; // 飞船爆炸
    public GameObject monsterExplosion; // 敌人爆炸


    public int scoreValue=10;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        if (gameController == null)
            Debug.Log("找不到GameController脚本");
    }

    void OnTriggerEnter(Collider coll)
    {
        // 如果与之碰撞的物体是外围边界则不做处理
        if (coll.tag == "Boundary") return;
        // 自己碰撞不处理
        if (coll.tag == gameObject.tag) return;
        // 同类碰撞不处理
        if ((coll.tag == "Enemy" && gameObject.tag == "Stars") || (coll.tag == "Stars" && gameObject.tag == "Enemy")) return;
        // 自己的武器不能杀自己
        if (coll.tag == "mBolt" && gameObject.tag != "Player") return;
        if (gameObject.tag == "mBolt" && coll.tag != "Player") return;

        gameController.AddScore(scoreValue);

        // 否则爆炸销毁
        GameObject.Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        if (coll.tag == "Player")
        {
            gameController.GameOver();
            GameObject.Instantiate(playerExplosion, coll.transform.position, coll.transform.rotation);
        }
        if (coll.tag == "Enemy")
        {
            GameObject.Instantiate(monsterExplosion, coll.transform.position, coll.transform.rotation);
            gameController.AddScore(5);
        }
        Destroy(gameObject);
        Destroy(coll.gameObject);
    }
}
