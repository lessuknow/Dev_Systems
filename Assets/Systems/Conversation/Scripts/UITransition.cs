using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITransition : MonoBehaviour {

    private Vector3 endPos, initPos;
    public bool transition = false;
    float totalTime = 0.0f;
    private bool onScreen = false;
    public bool moveLTRX, moveRTLX, moveDTUY, moveUTDY;
    
    private void Awake()
    {
        endPos = transform.position;
        float endX = GetComponent<RectTransform>().anchoredPosition.x, endY = GetComponent<RectTransform>().anchoredPosition.y;
        if (moveLTRX)
            endX = -Screen.width/2 - Mathf.Abs(endX);
        if (moveRTLX)
            endX = Screen.width/2 + Mathf.Abs(endX);
        if (moveDTUY)
            endY = -Screen.height / 2 - Mathf.Abs(endY);
        if (moveUTDY)
            endY = Screen.height / 2 + Mathf.Abs(endY);
        GetComponent<RectTransform>().localPosition = new Vector2(endX, endY);
        initPos = transform.position;


        transform.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    public bool IsOnScreen()
    {
        return onScreen;
    }

    public void Enable()
    {
        if(!onScreen)
        { 
            transition = true;
        }
        else
            onScreen = true;
    }

    public void Disable()
    {
        if(onScreen)
        { 
            transition = true;
        }
        else
            onScreen = false;
    }

	// Update is called once per frame
	void Update () {
		if(transition)
        {
            if(!onScreen)
            { 
                totalTime += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, endPos, totalTime);

                transform.GetComponent<Image>().color = Color.Lerp(transform.GetComponent<Image>().color,
                    new Color(1, 1, 1,1),totalTime);
                if (totalTime > 1)
                {
                    totalTime = 0;
                    transition = false;
                    onScreen = true;
                }
            }
            else
            {
                totalTime += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, initPos, totalTime);

                transform.GetComponent<Image>().color = Color.Lerp(transform.GetComponent<Image>().color,
                    new Color(1, 1, 1, 0), totalTime);
                if (totalTime > 1)
                {
                    totalTime = 0;
                    transition = false;
                    onScreen = false;
                }

            }
        }
	}
}
