using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;

    private float _maxValue;
    // Start is called before the first frame update
    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    // Update is called once per frame
    public void DealDamage(float damage) 
    {
        value -= damage;
        if (value <= 0)
        {
            gameplayUI.SetActive(false);
            gameOverScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            animator.SetTrigger("Death");
        }
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value/_maxValue, 1);
    }
    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }
    
}
