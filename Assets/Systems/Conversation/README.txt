Load the "Chat" scene into whatever scene you want to use. Remove the Debug_Interaction script from the UI Gameobject.

Text/GUIDE.txt has an example on how to write the text for it to be parsed. There's 3 example scripts (ending.txt, rhoodAndWolf.txt, TestInteraction.txt).

Call ParseText gameObject.LoadText() to load whatever text file is stored currently in the ParseText gameObject.

To step through the dialogue, call CurrentEvent gameObject.ParseEvent(). ParseEvent() returns true if it can still progress through the event, and false if the event is finished.