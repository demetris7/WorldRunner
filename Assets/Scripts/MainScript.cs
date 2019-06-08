using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public List<GameObject> coins, obstacles, offRoad;
    public float timeWaitMin = 2, timeWaitMax = 9;
    Vector3 pos1, pos2, pos3;
    public static int score = 0;
    public static float m_speed = -20f;
    public static bool isGameOver = false;

    public string menu = "Menu";
    public float x = 0.15f;

    private Text score1Text, speed1Text, gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        pos1 = new Vector3(-0.05f, 0, 0.51f);
        pos2 = new Vector3(0, 0, 0.5f);
        pos3 = new Vector3(0.05f, 0, 0.51f);
        StartCoroutine(spawnAll());
        StartCoroutine(spawnTrees());

        score1Text = GameObject.Find("Score_1").GetComponent<Text>();
        speed1Text = GameObject.Find("Speed_1").GetComponent<Text>();
        gameOverText = GameObject.Find("Game_Over").GetComponent<Text>();
        gameOverText.text = "";

    }

    IEnumerator spawnAll()
    {
        while (true)
        {
            if (!MainScript.isGameOver) {
                int numberObstacles = 0;
                int numberCoins = 0;
                for(int index = 0; index < 3; index++)
                {
                    GameObject gameObject = null;
                    Vector3 ori = new Vector3();

                    int r = Random.Range(0, 2);

                    if (r == 0 && coins.Count != 0 && numberCoins < 2)
                    {
                        gameObject = coins[Random.Range(0, coins.Count)];
                        ori = spawnCoins(index);
                        numberCoins++;
                    }
                    else if (obstacles.Count != 0 && numberObstacles < 2)
                    {
                        gameObject = obstacles[Random.Range(0, obstacles.Count)];
                        ori = spawnObstacle(index);
                        numberObstacles++;
                    }

                    if(gameObject != null)
                        Instantiate(gameObject, ori, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(Random.Range(((m_speed * -1) / 20) + 3, ((m_speed * -1) / 10) + 3));
        }
    }

    IEnumerator spawnTrees()
    {
        while (m_speed != 0)
        {
            if (offRoad.Count != 0)
            {
                GameObject tree = offRoad[Random.Range(0, offRoad.Count)];
                int lr = Random.Range(0, 3);
                if (lr == 0)
                {
                    Instantiate(tree, new Vector3(x, 0, 0.45f), Quaternion.identity);
                }
                else if (lr == 1)
                {
                    Instantiate(tree, new Vector3(x, 0, 0.45f), Quaternion.identity);
                    Instantiate(tree, new Vector3(-x, 0, 0.45f), Quaternion.identity);
                }
                else
                {
                    Instantiate(tree, new Vector3(-x, 0, 0.45f), Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    Vector3 spawnCoins(int r)
    {
        Vector3 ori;
        switch (r)
        {
            case 0:
                ori = pos1;
                break;
            case 1:
                ori = pos2;
                ori.z = 0.52f;
                break;
            default:
                ori = pos3;
                break;
        }
        return ori;
    }

    Vector3 spawnObstacle(int r)
    {
        Vector3 ori;
        switch (r)
        {
            case 0:
                ori = new Vector3(-0.055f, 0, 0.4881f);
                break;
            case 1:
                ori = new Vector3(0, 0, 0.4981f);
                break;
            default:
                ori = new Vector3(0.055f, 0, 0.4881f);
                break;
        }
        return ori;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(menu);
        if (!isGameOver)
        {
            score1Text.text = "Score: " + score;
            speed1Text.text = "Speed: " + (m_speed * -1) / 20;
        }
        if (isGameOver)
        {
            gameOverText.text = "Game Over\nScore: " + score;
        }
    }

    public static void gameOver()
    {
        m_speed = 0;
        isGameOver = true;
    }
}
