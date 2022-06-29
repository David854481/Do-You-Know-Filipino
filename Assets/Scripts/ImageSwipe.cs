using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwipe : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private float originalPositionX;


    private void Awake()
    {
        //get random img related to category
    }

    private void Start()
    {
        originalPositionX = transform.position.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, transform.position.y, transform.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckImagePosition();
    }

    private void CheckImagePosition()
    {
        Vector3 screenUpperRightCorner = Camera.main.ViewportToScreenPoint(new
            Vector3(1, 1, 0));
        Vector3 screenLowerLeftCorner = Camera.main.ViewportToScreenPoint(new
            Vector3(0, 0, 0));

        //Check image position on the screen
        if (transform.position.x > screenUpperRightCorner.x || transform.position.x < screenLowerLeftCorner.x) //Check if image is past screen borders
        {
            //check answer and do some logic to add score or remove life
        }
        else //reset image position if image is still within borders
            transform.position = new Vector3(originalPositionX, transform.position.y, transform.position.z);

    }
}
