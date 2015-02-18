#pragma strict

function Start () {

}

function Update () {

}

function OnGUI()

	{
		GUI.Label(Rect(Screen.width/2 - 85,Screen.height/8,250,50), "Choose your Graphics Quallity");
	
	
			if(GUI.Button(Rect(Screen.width /2 - 100 ,Screen.height /2 -250 ,250,50), "Fastest"))
			{
				QualitySettings.currentLevel = QualityLevel.Fastest;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 100 ,Screen.height /2 - 200,250,50), "Fast"))
			{
				QualitySettings.currentLevel = QualityLevel.Fast;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 100 ,Screen.height /2 - 150,250,50), "Simple"))
			{
				QualitySettings.currentLevel = QualityLevel.Simple;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 100 ,Screen.height /2 - 100,250,50), "Good"))
			{
				QualitySettings.currentLevel = QualityLevel.Good;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 100 ,Screen.height /2 - 50,250,50), "Beautiful"))
			{
				QualitySettings.currentLevel = QualityLevel.Beautiful;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 100 ,Screen.height /2 ,250,50), "Fantastic"))
			{
				QualitySettings.currentLevel = QualityLevel.Fantastic;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 50 ,Screen.height /2 + 280 ,150,50), "Go Back"))
			{
				Application.LoadLevel(4);
			}
			
			if(GUI.Button(Rect(Screen.width /2- 120 ,Screen.height /2 + 150 ,50,50), "0"))
			{
				AudioListener.volume = 0.0;
			}
			
			if(GUI.Button(Rect(Screen.width /2- 70 ,Screen.height /2 + 150 ,50,50), "1"))
			{
				AudioListener.volume = 0.2;
			}
			
			if(GUI.Button(Rect(Screen.width /2 - 20 ,Screen.height /2 + 150 ,50,50), "2"))
			{
				AudioListener.volume = 0.4;
			}
			
			if(GUI.Button(Rect(Screen.width /2+ 30 ,Screen.height /2 + 150 ,50,50), "3"))
			{
				AudioListener.volume = 0.6;
			}
			
			if(GUI.Button(Rect(Screen.width /2 + 80 ,Screen.height /2 + 150 ,50,50), "4"))
			{
				AudioListener.volume = 0.8;
			}
			
			
			GUI.Label(Rect(Screen.width/2 - 140,Screen.height/2 + 90,350,50), "Choose your Volume Settings from Low to High");
			
			if(GUI.Button(Rect(Screen.width /2+ 130 ,Screen.height /2 + 150 ,50,50), "5"))
			{
				AudioListener.volume = 1.0;
			}
			
		}