using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private List<LevelUpCard> _cards = new List<LevelUpCard>();
    [SerializeField] private RectTransform _content;
    [SerializeField] private TextMeshProUGUI _levelUpText;

    private CanvasGroup _cg;

    private const int NUMBER_OF_CHOICES = 3;
    
    private void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    private List<LevelUpCard> GetRandomLevelUpChoices()
    {
        List<LevelUpCard> choices = new List<LevelUpCard>(_cards);
        List<LevelUpCard> chosenCards = new List<LevelUpCard>();

        for (int i = 0; i < NUMBER_OF_CHOICES; i++)
        {
            LevelUpCard card = choices[Random.Range(0, choices.Count)];
            chosenCards.Add(card);
            card.SetLevelUpPanel(this);
            choices.Remove(card);
        }

        return chosenCards;
    }

    private void SetCards(List<LevelUpCard> cards)
    {
        foreach(Transform child in _content)
        {
            Destroy(child.gameObject);
        }
        foreach(LevelUpCard levelUpCard in cards)
        {
            Instantiate(levelUpCard, _content);
        }
    }

    private void OpenPanel(int currentlevel)
    {
        Time.timeScale = 0f;
        _cg.alpha = 1.0f;
        _cg.interactable = true;
        _cg.blocksRaycasts = true;

        _levelUpText.text = $"Level {currentlevel}!";
        SetCards(GetRandomLevelUpChoices());
    }

    public void ClosePanel()
    {
        Time.timeScale = 1f;
        _cg.alpha = 0f;
        _cg.interactable = false;
        _cg.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        LevelUpManager.Instance.OnLevelUp += OpenPanel;
    }

    private void OnDisable()
    {
        LevelUpManager.Instance.OnLevelUp -= OpenPanel;
    }
}
