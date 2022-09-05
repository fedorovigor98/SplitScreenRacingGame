using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    [SerializeField] private Image healthbarSprite;


    public void UpdateHealthbar(float maxhp, float currenthp)
    {
        healthbarSprite.fillAmount = currenthp / maxhp;
    }
}
