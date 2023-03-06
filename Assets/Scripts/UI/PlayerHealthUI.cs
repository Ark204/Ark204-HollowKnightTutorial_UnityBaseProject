using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    Text healthText;
    Image healthSlider;

    private void Awake()
    {
        healthText = transform.GetChild(1).GetComponent<Text>();
        healthSlider = transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        healthText.text = playerData.HP + "/" + playerData.MaxHp;
        float sliderPercent = (float)playerData.HP / playerData.MaxHp;
        healthSlider.fillAmount = sliderPercent;

    }

}
