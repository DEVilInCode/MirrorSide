using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///Класс отвечает за отображение полей класса "Существо" на объекте карты
///<summary>
public class MinionUI : BasicCardUI
{
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI HealthText;
    
    public void Awake()
    {
        if (Card == null)
            return;

        if(Card is MinionData mCard)
            UpdateView(mCard);
       
    }

    public void UpdateView(MinionData minionCard) {
        base.UpdateView(minionCard);
        DamageText.text = minionCard.Damage.ToString();
        HealthText.text = minionCard.Health.ToString();
    }
}
