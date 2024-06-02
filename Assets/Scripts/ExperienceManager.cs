using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private float _experience = 0;
    [SerializeField] private float _nextLevelExperience;

    private int _level;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _experienceScale;

    [SerializeField] private EffectsManager _effectsManager;

    [SerializeField] private AnimationCurve _experienceCurve;

    private void Awake()
    {
        _nextLevelExperience = _experienceCurve.Evaluate(0);
    }
    public void AddExperience(int value)
    {
        _experience += value;
        if (_experience >= _nextLevelExperience)
        {
            UpLevel();
        }
        DisplayExperence();
    }

    public void UpLevel()
    {
        _level++;
        _effectsManager.ShowCards();
        _levelText.text = _level.ToString();
        _experience = 0;
        _nextLevelExperience = _experienceCurve.Evaluate(_level);
    }

    // Метод для обновления шкалы набора опыта
    private void DisplayExperence()
    {
        _experienceScale.fillAmount = _experience/_nextLevelExperience;
    }
}
