using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public int count = 10;
    public GameObject star;
    public GameObject monster;
    public Vector3 spawnValues;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    // 计分部分
    public Text scoreText;
    private int score;
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "得分: " + score;
    }

    // 游戏结束
    public Text gameOverText, subText;
    private bool gameOver = false;
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "游戏结束";
        subText.text = "请等待这一轮结束后按[R]重新开始";
    }

    // 游戏重启
    public Text restartText;
    private bool restart = false;

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(2.5f);
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),
                    0.0f, spawnValues.z);
                spawnRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                GameObject.Instantiate(monster, spawnPosition, spawnRotation);

                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
                GameObject.Instantiate(star, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(1.5f);
            }
            if(gameOver)
            {
                restartText.text = "按[R]键重新开始";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(2.0f);
        }
    }
	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
        gameOver = false;
        gameOverText.text = subText.text = "";
        restart = false;
        restartText.text = "";
        StartCoroutine(Generator());
	}
	
	// Update is called once per frame
	void Update () {
	    if(restart && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
