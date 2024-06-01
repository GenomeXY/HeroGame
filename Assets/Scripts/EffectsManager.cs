using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private List<ContinuousEffect> _continuousEffectsApplied = new List<ContinuousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffectsApplied = new List<OneTimeEffect>();

    [SerializeField] private List<ContinuousEffect> _continuousEffects = new List<ContinuousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffects = new List<OneTimeEffect>();

    [SerializeField] private CardManager _cardManager;

    private void Awake()
    {
        // ��������� ����� �������, ����� �� �������� ���������

        for (int i = 0; i < _continuousEffects.Count; i++)
        {
            _continuousEffects[i] = Instantiate(_continuousEffects[i]);
        }

        for (int i = 0; i < _oneTimeEffects.Count; i++)
        {
            _oneTimeEffects[i] = Instantiate(_oneTimeEffects[i]);
        }
    }

    [ContextMenu("ShowCards")]
    public void ShowCards()
    {
        // List �������� �� �������� ����� ������� 3 ���������
        List<Effect> effectsToShow = new List<Effect>();

        // ����������� Continuous �������
        for (int i = 0; i < _continuousEffectsApplied.Count; i++)
        {
            if (_continuousEffectsApplied[i].Level < 10)
                effectsToShow.Add(_continuousEffectsApplied[i]);
        }

        // ����������� OneTime �������
        for (int i = 0; i < _oneTimeEffectsApplied.Count; i++)
        {
            if (_oneTimeEffectsApplied[i].Level < 10)
                effectsToShow.Add(_oneTimeEffectsApplied[i]);
        }

        // �� ����������� Continuous �������
        if (_continuousEffectsApplied.Count < 4)
            effectsToShow.AddRange(_continuousEffects);

        // �� ����������� OneTime �������
        if (_oneTimeEffectsApplied.Count < 4)
            effectsToShow.AddRange(_oneTimeEffects);

        // ���������� ����, ������� ����� ��������.
        // ���� � ������ effectsToShow �� ����� ���������� ������ ��� 3
        int numberOfCardsToShow = Mathf.Min(effectsToShow.Count, 3);

        // ������������ ����� � ������� List effectsForCards,
        // � ������� ����� 3 ��������� ����� �� ������ effectsToShow
        int[] randomIndexes = RandomSort(effectsToShow.Count, numberOfCardsToShow);

        List<Effect> effectsForCards = new List<Effect>();
        for (int i = 0; i < randomIndexes.Length; i++)
        {
            int index = randomIndexes[i];
            effectsForCards.Add(effectsToShow[index]);
        }

        _cardManager.ShowCards(effectsForCards);
    }

    int[] RandomSort(int length, int number)
    {
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        for (int i = 0; i < array.Length; i++)
        {
            int oldValue = array[i];
            int newIndex = UnityEngine.Random.Range(0, array.Length);
            array[i] = array[newIndex];
            array[newIndex] = oldValue;
        }
        int[] result = new int[number];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }
        return result;
    }

    public void AddEffect(Effect effect)
    {
        // ���������� ������� �� ������ �� ����������� � ������ �����������
        if (effect is ContinuousEffect c_effect)
        {
            if (!_continuousEffectsApplied.Contains(c_effect))
            {
                _continuousEffectsApplied.Add(c_effect);
                _continuousEffects.Remove(c_effect);
            }
        }
        else if (effect is OneTimeEffect one_effect)
        {
            if (!_oneTimeEffectsApplied.Contains(one_effect))
            {
                _oneTimeEffectsApplied.Add(one_effect);
                _oneTimeEffects.Remove(one_effect);
            }
        }
        // ���������� ������
        effect.Activate();
    }
}
