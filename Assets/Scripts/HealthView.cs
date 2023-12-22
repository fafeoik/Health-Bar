using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthAmountText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private float _smoothBarSpeed;

    private char _separatorMark = '/';
    private Coroutine _smoothHealthChangeCoroutine;

    private void OnDisable()
    {
        if (_smoothHealthChangeCoroutine != null)
        {
            StopCoroutine(_smoothHealthChangeCoroutine);
        }
    }

    public void ShowHealth(int currentHealth, int maxHealth)
    {
        ShowTextHealth(currentHealth, maxHealth);
        ShowHealthBar(currentHealth);
        ShowSmoothHealthBar(currentHealth);
    }

    private void ShowSmoothHealthBar(int currentHealth)
    {
        _smoothHealthChangeCoroutine = StartCoroutine(ChangeHealthSmoothly(currentHealth));
    }

    private void ShowHealthBar(int currentHealth)
    {
        _healthBar.value = currentHealth;
    }

    private void ShowTextHealth(int health, int maxHealth)
    {
        _healthAmountText.text = health.ToString();
        _healthAmountText.text += _separatorMark;
        _healthAmountText.text += maxHealth.ToString();
    }

    private IEnumerator ChangeHealthSmoothly(int currentHealth)
    {
        bool isWorking = true;

        while (isWorking)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, currentHealth, _smoothBarSpeed);

            if(_smoothHealthBar.value == currentHealth)
            {
                isWorking = false;
            }

            yield return null;
        }
    }
}
