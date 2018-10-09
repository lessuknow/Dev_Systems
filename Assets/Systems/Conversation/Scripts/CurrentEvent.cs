using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEvent : MonoBehaviour {
    [HideInInspector] public PrintText text;
    [HideInInspector] public List<string> events;
    public GameObject person_left, person_right, textbox;
    private char person_left_char, person_right_char;
    private int current_position = 0;

    public void Restart()
    {
        current_position = 0;
    }

    //Returns true if there are still events, else returns false.
    public bool ParseEvent()
    {
        if (current_position >= events.Count)
        {
            person_left.GetComponent<UITransition>().Disable();
            person_right.GetComponent<UITransition>().Disable();
            textbox.GetComponent<UITransition>().Disable();
            return false;
        }
        string s = events[current_position];
        
        //Entering
        if(s[0] == '-')
        {
            //Enter
            if (s[4] == 'l')
            {
                //Left 
                if(s[3] == 'e')
                {
                    person_left.GetComponent<UITransition>().Enable();
                }
                else if (s[3] == 'x')
                {
                    person_left.GetComponent<UITransition>().Disable();
                }
                switch (s[1])
                {
                    case 'W':
                        person_left.GetComponent<UIPerson>().SetChar(UIPerson.character.wolf);
                        person_left_char = 'W';
                        break;
                    case 'R':
                        person_left.GetComponent<UIPerson>().SetChar(UIPerson.character.rhood);
                        person_left_char = 'R';
                        break;
                    case 'H':
                        person_left.GetComponent<UIPerson>().SetChar(UIPerson.character.hunter);
                        person_left_char = 'H';
                        break;
                }
                person_left_char = s[1];
            }
            else if (s[4] == 'r')
            {
                //Left 
                if (s[3] == 'e')
                {
                    person_right.GetComponent<UITransition>().Enable();
                }
                else if (s[3] == 'x')
                {
                    person_right.GetComponent<UITransition>().Disable();
                }
                switch (s[1])
                {
                    case 'W':
                        person_right.GetComponent<UIPerson>().SetChar(UIPerson.character.wolf);
                        person_right_char = 'W';
                        break;
                    case 'R':
                        person_right.GetComponent<UIPerson>().SetChar(UIPerson.character.rhood);
                        person_right_char = 'R';
                        break;
                    case 'H':
                        person_right.GetComponent<UIPerson>().SetChar(UIPerson.character.hunter);
                        person_right_char = 'H';
                        break;
                }
                person_right_char = s[1];
            }
            current_position++;
            return ParseEvent();
        }
        else
        {
            if (s[0] == person_left_char)
            {
                person_left.GetComponent<UIPerson>().Fade_In();
                person_right.GetComponent<UIPerson>().Fade_Out();
            }
            else if(s[0] == person_right_char)
            {
                person_left.GetComponent<UIPerson>().Fade_Out();
                person_right.GetComponent<UIPerson>().Fade_In();
            }

            if(!textbox.GetComponent<UITransition>().IsOnScreen())
            {
                textbox.GetComponent<UITransition>().Enable();
            }
            if (textbox.GetComponent<PrintText>().IsTextComplete())
                current_position++;
            textbox.GetComponent<PrintText>().SetText(s.Substring(2));
        }
        return true;
      
    }

}
