using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPerson : MonoBehaviour {

    private Image img;
    public enum character { wolf, hunter, rhood };
    public Sprite wolfSpirte, hunterSpirte, rhoodSprite;
    public character curChar;
    private bool transition = false, faded = true;
    private float totalTime = 0.0f;

    static Color faded_color = new Color(0.25f, 0.25f, 0.25f, 1);

    private void Start()
    {
        img = GetComponent<Image>();
        img.color = new Color(0.25f, 0.25f, 0.25f, 1);
    }

    public void Fade_In()
    {
        if(faded)
        {
            transition = true;
        }
    }

    public void Fade_Out()
    {
        if(!faded)
        {
            transition = true;
        }
    }

    public void SetChar(character c)
    {
        curChar = c;
        switch (c)
        {
            case character.wolf:
                img.sprite = wolfSpirte;
                break;
            case character.hunter:
                img.sprite = hunterSpirte;
                break;
            case character.rhood:
                img.sprite = rhoodSprite;
                break;
        }
    }

    private void Update()
    {
        if (transition)
        {
            if (faded)
            {
                totalTime += Time.deltaTime;
                img.color = Color.Lerp(transform.GetComponent<Image>().color,
                    new Color(1, 1, 1, 1), totalTime);
                if (totalTime > 0.55)
                {
                    totalTime = 0;
                    transition = false;
                    faded = false;
                }
            }
            else
            {
                totalTime += Time.deltaTime;
                img.color = Color.Lerp(transform.GetComponent<Image>().color,
                    faded_color, totalTime);
                if (totalTime > 0.55)
                {
                    totalTime = 0;
                    transition = false;
                    faded = true;
                }

            }
        }
    }
}
