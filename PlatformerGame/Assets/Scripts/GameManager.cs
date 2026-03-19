using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Text = UnityEngine.UI.Text;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform respawnPoint;
    public GameObject player;
    public Text scoreText;
    public Text winText;

    private int score = 0;
    private int totalCoins = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        totalCoins = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        Debug.Log("Total coins found: " + totalCoins);
        UpdateScoreUI();
        winText.gameObject.SetActive(false);
    }

    public void RespawnPlayer()
    {
        player.transform.position = respawnPoint.position;
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score: " + score + " / " + totalCoins);
        UpdateScoreUI();
        if (score >= totalCoins) WinGame();
    }

    void UpdateScoreUI()
    {
        if (scoreText) scoreText.text = "Coins: " + score + " / " + totalCoins;
    }

    void WinGame()
    {
        Debug.Log("WIN TRIGGERED!");
        winText.gameObject.SetActive(true);
        winText.text = "YOU WIN!";
        Invoke("ReloadScene", 3f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}