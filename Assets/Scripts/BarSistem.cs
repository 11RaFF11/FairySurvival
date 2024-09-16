using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSistem : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private Image staminaBar;
    [SerializeField] private Player player;

    private void Update()
    {
        Bars();
    }

    private void Bars()
    {
        staminaBar.fillAmount = player.stamina/player.maxStamina;
    }
}
