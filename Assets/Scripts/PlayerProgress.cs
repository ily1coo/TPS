using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;
    
    private int _levelValue = 1;
    
    public float _experienceCurrentValue = 0;
    public float _experienceTargerValue = 100;

    private void Start()
    {
        DrawUI();
        levelValueTMP.text = Random.Range(0,10).ToString();
    }

    private void Update()
    {
        // DrawUI();
       // levelValueTMP.text = Random.Range(0,10).ToString();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargerValue)
        {
            _levelValue += 1;
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }
    private void DrawUI()
    {
         experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargerValue, 1);
         levelValueTMP.text = _levelValue.ToString();
    }
}
