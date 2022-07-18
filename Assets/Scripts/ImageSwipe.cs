using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwipe : MonoBehaviour, IDragHandler, IEndDragHandler
{    
    [SerializeField] private float percentThreshold = 0.2f;
    [SerializeField] private float easing = 0.5f;

    private Vector3 panelLocation;
    private Vector3 initialPosition;

    private bool didPlayerAnswer = false;
    public bool ImageItemAnswer { get; set; }
    private void Awake()
    {
        //get random img related to category
        ImageItemAnswer = false; //for testing only
    }

    private void Start()
    {
        initialPosition = transform.position;
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0)
                newLocation += new Vector3(-Screen.width, 0, 0);
            else
                newLocation += new Vector3(Screen.width, 0, 0);
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;

            AudioManager.Instance.Play("SwipeImageSfx");
            didPlayerAnswer = true;
        }
        else
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    }

    private IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
    {
        float time = 0f;
        while(time <= 1f)
        {
            time += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, time));
            yield return null;
        }
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
            if (transform.position.x > screenUpperRightCorner.x)
            {
                //Debug.Log("right");
                GameController.Instance.CheckPlayerAnswer(true, ImageItemAnswer);
                didPlayerAnswer = false;
            }

            else if (transform.position.x < screenUpperRightCorner.x)
            {
                //Debug.Log("left");
                GameController.Instance.CheckPlayerAnswer(false, ImageItemAnswer);
                didPlayerAnswer = false;
            }
        }
    }

    private void Update()
    {
        if(didPlayerAnswer)
            CheckImagePosition();
    }
}
