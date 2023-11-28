using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellUI : BasicCardUI
{

    public void Awake()
    {
        if (Card == null)
            return;

        if (Card is SpellData sCard)
            UpdateView(sCard);

    }

    public void UpdateView(SpellData SpellCard)
    {
        base.UpdateView(SpellCard);
    }
}
