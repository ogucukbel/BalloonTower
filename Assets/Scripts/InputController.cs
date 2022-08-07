using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject balloonPrefab;
    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(balloonPrefab, Vector3.zero, Quaternion.identity);
    }
}
