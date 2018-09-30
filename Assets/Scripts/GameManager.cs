using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform target;
    public Transform spawnPoint;
    public GameObject pinPrefab;

    public Text scoreText;

    private Camera mainCamera;

    private int score;

    private bool isGameOver = false;

    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
        InvokeRepeating("SpawnPin", 1f, 0.1f);
    }

    private void Update()
    {

        if (isGameOver) return;

        if (Input.GetMouseButtonDown(0))
        {
            SpawnPin();
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
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

        StartCoroutine(StartGameOver());

        isGameOver = true;
        target.GetComponent<RotateSelf>().enabled = false;
    }

    private IEnumerator StartGameOver()
    {

        while (true)
        {

            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, Time.deltaTime);

            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4f, Time.deltaTime);

            if (Mathf.Abs(mainCamera.orthographicSize - 4f) < 0.1f)
            {
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
