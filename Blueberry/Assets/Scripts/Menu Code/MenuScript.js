#pragma strict
var menuFont : Font;

function Start () {

}

function Update () {

}

function OnGUI()
		
		{
			
			GUI.skin.box.font = menuFont;
			GUI.skin.button.font = menuFont;
			GUI.skin.label.font = menuFont;
			
			GUI.Label(Rect(Screen.width /2.25,Screen.height /8,250,50), "Don't be a BlueBerry!");

			if (GUI.Button(Rect(Screen.width /2.25,Screen.height /4 ,150,50), "Play"))
			{
				Application.LoadLevel(3);
				
			}

			if (GUI.Button(Rect(Screen.width /2.25,Screen.height /3 ,150,50), "HighScore"))
			{
			Application.LoadLevel(5);
			
			}
			
			
			if (GUI.Button(Rect(Screen.width /2.25,Screen.height /2.4 ,150,50), "Options"))
			{
			Application.LoadLevel(1);
			}
			
			if (GUI.Button(Rect(Screen.width /2.25,Screen.height /2.0 ,150,50), "Exit"))
			{
			Application.Quit();
			}


			
		
		}