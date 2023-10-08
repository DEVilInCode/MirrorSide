using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///Класс отвечает за отображение полей класса "Существо" на объекте карты
///<summary>
public class MinionDisplay : CardDisplay
{
    private TextMeshProUGUI _healthTextMesh;
    private TextMeshProUGUI _damageTextMesh;

    /// <summary>
    /// Находит все поля карты существа
    /// </summary>
    /// <exception cref="MissingComponentException"></exception>
    protected override void Awake()
    {
        base.Awake();

        if (!transform.Find("Health").TryGetComponent(out _healthTextMesh))
            throw new MissingComponentException(nameof(_healthTextMesh));

        if (!transform.Find("Damage").TryGetComponent(out _damageTextMesh))
            throw new MissingComponentException(nameof(_damageTextMesh));
    }

    /// <summary>
    /// Заполняет все поля карты существа
    /// </summary>
    /// <param name="minionData"></param>
    public void UpdateView(MinionData minionData) {
        base.UpdateView(minionData);
        _damageTextMesh.text = minionData.Damage.ToString();
        _healthTextMesh.text = minionData.Health.ToString();
    }
}
