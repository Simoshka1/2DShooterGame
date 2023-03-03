using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public static Score Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void AddPoints(int value)
    {
        _score += value;
        UpdateScore();
    }
}
