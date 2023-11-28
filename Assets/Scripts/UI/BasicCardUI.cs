using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///Класс отвечает за отображение общих полей на картах
///<summary>
public abstract class BasicCardUI : MonoBehaviour
{
    public BasicData Card;

    public TextMeshProUGUI CostText;
    public Image Artwork;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;

    public Image CardFaceGlowImage;

    private bool _canBePlayed = false;
    public bool CanBePlayed
    {
        get
        {
            return _canBePlayed;
        }
        set
        {
            _canBePlayed = value;
            CardFaceGlowImage.enabled = value;
        }
    }

    public void UpdateView(BasicData card)
    {
        CostText.text = card.Cost.ToString();
        //Artwork.sprite = card.Sprite;
        NameText.text = card.Name.ToString();
        DescriptionText.text = card.Description.ToString();
    }
}
