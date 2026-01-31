using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static AudioManager;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip _hoverSFX;

    [SerializeField] private float _hoverScaleIncrease = 1.1f;
    [SerializeField] private float _clickScaleIncrease = 1.3f;
    [SerializeField] private float _tweenEffectDuration = 0.1f;

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        LeanTween.cancel(gameObject);
        transform.localScale = Vector2.one * _clickScaleIncrease;
        LeanTween.scale(gameObject, Vector2.one, _tweenEffectDuration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector2.one / 1;
        LeanTween.scale(gameObject, Vector2.one, _tweenEffectDuration);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one * _hoverScaleIncrease, _tweenEffectDuration);
        Instance.PlayAudio(_hoverSFX, SoundType.SFX, 0.8f, false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one, _tweenEffectDuration);
    }
}