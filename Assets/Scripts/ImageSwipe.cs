using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwipe : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private void Awake()
    {
        //get random img related to category
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, transform.position.y, transform.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
