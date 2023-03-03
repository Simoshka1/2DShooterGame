using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _loseScreen;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowLoseScreen()
    {
        _gameScreen.SetActive(false);
        _loseScreen.SetActive(true);
    }
}