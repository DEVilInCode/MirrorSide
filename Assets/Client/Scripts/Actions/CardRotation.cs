using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CardRotation : MonoBehaviour
{
    // Faces of the card
    [SerializeField]
    private RectTransform cardFront, cardBack;

    void Update()
    {
        // Raycast from Camera to a target point on the face of the card
        // If it passes through the card`s collider, we should show the back of the card
        bool showBack = Physics.Raycast(origin: Camera.main.transform.position,
                        direction: (-Camera.main.transform.position + transform.position).normalized,
                        maxDistance: (-Camera.main.transform.position + transform.position).magnitude);
        cardFront.gameObject.SetActive(!showBack);
        cardBack.gameObject.SetActive(showBack);
    }
}