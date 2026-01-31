using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameOverPanelCG;

    private CanvasGroup _cg;

    public void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    public void ShowGameOverPanel()
    {
        _gameOverPanelCG.alpha = 1f;
        _gameOverPanelCG.interactable = true;
        _gameOverPanelCG.blocksRaycasts = true;
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.ResetGame();
    }

    public void ShowInGameUI()
    {
        _cg.alpha = 1f;
        _cg.interactable = true;
        _cg.blocksRaycasts = true;
    }
}
