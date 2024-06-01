using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // ��� �������, ����� ���� ����� ��� ���������
    [SerializeField] private Image _iconBackground;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _continuousEffectSprite;
    [SerializeField] private Sprite _oneTimeEffectSprite;

    private Effect _effect;
    public void Show(Effect effect)
    {
        _effect = effect;
        _nameText.text = effect.Name;
        _descriptionText.text = effect.Description;
        _levelText.text = effect.Level.ToString();
        _iconImage.sprite = effect.Sprite;

        if(effect is ContinuousEffect)
        {
            _iconBackground.sprite = _continuousEffectSprite;
        }
        else if (effect is OneTimeEffect)                 
        {
            _iconBackground.sprite= _oneTimeEffectSprite;
        }
    }
}
