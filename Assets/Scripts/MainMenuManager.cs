using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mainMenuButtonsCG;
    [SerializeField] private CanvasGroup _quitConfirmationCG;
    [SerializeField] private CanvasGroup _settingsMenuCG;

    [SerializeField] private AudioClip _menuSFX;

    private CanvasGroup _cg;

    private void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        _cg.alpha = 1.0f;
        _cg.interactable = true;
        _cg.blocksRaycasts = true;
    }

    public void CloseMainMenu()
    {
        AudioManager.Instance.PlayAudio(_menuSFX, AudioManager.SoundType.SFX, 0.8f, false);
        _cg.alpha = 0.0f;
        _cg.interactable = false;
        _cg.blocksRaycasts = false;
    }

    public void Play()
    {
        AudioManager.Instance.PlayAudio(_menuSFX, AudioManager.SoundType.SFX, 0.8f, false);
        CloseMainMenu();
        GameManager.Instance.StartGame();
    }

    public void Quit()
    {
        AudioManager.Instance.PlayAudio(_menuSFX, AudioManager.SoundType.SFX, 0.8f, false);
        Application.Quit();
        Debug.Log("Quit!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OpenQuitConfirmation()
    {
        AudioManager.Instance.PlayAudio(_menuSFX, AudioManager.SoundType.SFX, 0.8f, false);
        _mainMenuButtonsCG.alpha = 0.0f;
        _mainMenuButtonsCG.interactable = false;
        _mainMenuButtonsCG.blocksRaycasts = false;

        _quitConfirmationCG.alpha = 1.0f;
        _quitConfirmationCG.interactable = true;
        _quitConfirmationCG.blocksRaycasts = true;
    }

    public void CloseQuitConfirmation()
    {
        AudioManager.Instance.PlayAudio(_menuSFX, AudioManager.SoundType.SFX, 0.8f, false);
        _mainMenuButtonsCG.alpha = 1.0f;
        _mainMenuButtonsCG.interactable = true;
        _mainMenuButtonsCG.blocksRaycasts = true;

        _quitConfirmationCG.alpha = 0.0f;
        _quitConfirmationCG.interactable = false;
        _quitConfirmationCG.blocksRaycasts = false;
    }

    public void SettingsMenuToggle(bool isOpening)
    {
        AudioManager.Instance.PlayAudio(_menuSFX, AudioManager.SoundType.SFX, 0.8f, false);
        _mainMenuButtonsCG.alpha = isOpening ? 0.0f : 1.0f;
        _mainMenuButtonsCG.interactable = !isOpening;
        _mainMenuButtonsCG.blocksRaycasts = !isOpening;

        _settingsMenuCG.alpha = isOpening ? 1.0f : 0.0f;
        _settingsMenuCG.interactable = isOpening;
        _settingsMenuCG.blocksRaycasts = isOpening;
    }
}
