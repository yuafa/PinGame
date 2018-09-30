using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Color[] colors;

    public Transform target;
    public Transform spawnPoint;
    public GameObject pinPrefab;

    public Text scoreText;

    private Camera mainCamera;

    private int score;

    private bool isGameOver = false;

    private float timer = 0f;

    private bool isNormalGame = true;

    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
        //InvokeRepeating("SpawnPin", 1f, 0.1f);
    }

    private void Start()
    {
        if (GameMode.instance.mode == Mode.Normal)
        {
            isNormalGame = true;
        }
        else
        {
            isNormalGame = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("01Main");
        }

        if (isGameOver) return;

        if (isNormalGame == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnPin();
            }
        }
        else
        {
            if (timer >= 0.1f)
            {
                timer = 0f;
                SpawnPin();
            }
            timer += Time.deltaTime;
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score == 996)
        {
            GameOver();
        }
    }

    private void SpawnPin()
    {
        GameObject pinGo = Instantiate(pinPrefab, spawnPoint.position, spawnPoint.rotation);
        Pin pin = pinGo.GetComponent<Pin>();
        pin.target = target;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        if (isNormalGame == true)
        {
            StartCoroutine(StartGameOver());
        }
    }

    private IEnumerator StartGameOver()
    {
        Color tempColor = colors[Random.Range(0, colors.Length)];

        while (true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, tempColor, Time.deltaTime);

            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 45f, Time.deltaTime);

            if (Mathf.Abs(mainCamera.fieldOfView - 45f) < 0.1f)
            {
                break;
            }

            yield return null;
        }
    }

}
