using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Range
{
    public float min, max;
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public Pool playerBulletPool;
    public Pool enemyBulletPool;
    public Pool[] enemyPools;

    public float spawnX;
    public Range spawnY;
    public float startWait;
    public Range interval;
    public float intervalAccel;

    public Text scoreText;
    public Text pauseText;
    public GameObject gameoverMenu;

    private bool _gameover;
    private bool _pause;
    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _gameover = false;
        _pause = false;
        _score = 0;

        UpdateScore();
        StartCoroutine(CoSpawnEnemys());
    }

    private void Update()
    {
        if(_gameover)
        {
            return; 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pause)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
            _pause = !_pause;
            UpdatePlayState();
        }
    }

    private IEnumerator CoSpawnEnemys()
    {
        yield return new WaitForSeconds(startWait);

        float generateInterval = interval.max;

        while(!_gameover)
        {
            Vector3 spawnPosition = new Vector3(spawnX, Random.Range(spawnY.min, spawnY.max), 0f);
            Pool enemyPool = enemyPools[Random.Range(0, enemyPools.Length)];
            PoolObject poolObj = enemyPool.Pop();
            poolObj.transform.position = spawnPosition;
            poolObj.transform.rotation = Quaternion.identity;

            yield return new WaitForSeconds(generateInterval);

            generateInterval = Mathf.Clamp(generateInterval - intervalAccel, interval.min, interval.max);
        }
    }

    public void AddScore(int add)
    {
        _score += add;
        UpdateScore();
    }

    public int GetScore()
    {
        return _score;
    }

    private void UpdateScore()
    {
        scoreText.text = _score.ToString();
    }

    private void UpdatePlayState()
    {
        pauseText.text = _pause ? "ESC : Resume" : "ESC : Pause";
    }

    public void Gameover()
    {
        StartCoroutine(CoGameover());
    }

    private IEnumerator CoGameover()
    {
        _gameover = true;
        gameoverMenu.SetActive(true);

        yield return new WaitForKeyDown(KeyCode.Return);

        gameoverMenu.SetActive(false);
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Additive);
    }

    public bool IsPaused()
    {
        return _pause;
    }

    public void Despawn(GameObject obj)
    {
        PoolObject poolObj = obj.GetComponent<PoolObject>();
        if (poolObj != null)
        {
            poolObj.Die();
        }
        else
        {
            Destroy(obj);
        }
    }
}
