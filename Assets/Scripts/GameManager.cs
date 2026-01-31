using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AudioManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private MainMenuManager _mainMenuManager;
    [SerializeField] private InGameUIManager _inGameUIManager;

    [SerializeField] private AudioClip _ambiance;

    [SerializeField] public TMP_Text _timerInfoText;

    private float _gameStartTime;
    private bool _isAlive;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        _inGameUIManager.ShowInGameUI();
        AudioManager.Instance.PlayAudio(_ambiance, SoundType.SFX, 0.5f, true);
        _isAlive = true;
        _gameStartTime = Time.time;
    }

    void Update()
    {
        if (_isAlive)
        {
            _timerInfoText.text = TimeParser(Time.time - _gameStartTime);
        }
        else
        {
            _timerInfoText.text = "";
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _isAlive = false;
        _inGameUIManager.ShowGameOverPanel();
    }

    private string TimeParser(float time)
    {
        float minutes = Mathf.Floor((time) / 60);
        float seconds = Mathf.Floor((time) % 60);
        float msecs = Mathf.Floor(((time) * 100) % 100);
        return (minutes.ToString() + ":" + seconds.ToString("00") + ":" + msecs.ToString("00"));
    }
}
