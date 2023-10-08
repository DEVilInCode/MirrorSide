using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///Класс отвечает за отображение общих полей на картах
///<summary>
public abstract class CardDisplay : MonoBehaviour
{
    private Image _artwork;

    private TextMeshProUGUI _costTextMesh;
    private TextMeshProUGUI _nameTextMesh;
    private TextMeshProUGUI _descriptionTextMesh;

    /// <summary>
    /// Находит основные поля необходимые для карты
    /// </summary>
    /// <exception cref="MissingComponentException"></exception>
    protected virtual void Awake()
    {
        if (!transform.Find("Cost").TryGetComponent(out _costTextMesh))
            throw new MissingComponentException(nameof(_costTextMesh));

        if (!transform.Find("Image").TryGetComponent(out _artwork))
            throw new MissingComponentException(nameof(_artwork));

        if (!transform.Find("Name").TryGetComponent(out _nameTextMesh))
            throw new MissingComponentException(nameof(_nameTextMesh));

        if (!transform.Find("Description").TryGetComponent(out _descriptionTextMesh))
            throw new MissingComponentException(nameof(_descriptionTextMesh));
    }

    /// <summary>
    /// Заполняет основные поля
    /// </summary>
    /// <param name="cardData"></param>
    public void UpdateView(CardData cardData)
    {
        _costTextMesh.text = cardData.Cost.ToString();
        _artwork.sprite = cardData.Sprite;
        _nameTextMesh.text = cardData.Name.ToString();
        _descriptionTextMesh.text = cardData.Description.ToString();
    }
}
