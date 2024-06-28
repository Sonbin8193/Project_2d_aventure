using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }
    VisualElement m_healthBar;
    float currentHealth;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument document = GetComponent<UIDocument>();
        m_healthBar = document.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealth(1f);
    }
    public void SetHealth(float percentage)
    {
        m_healthBar.style.width = Length.Percent(100 * percentage);
    }
}

