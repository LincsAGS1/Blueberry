var mainMenuSceneName : String;
var pauseMenuFont : Font;
private var pauseEnabled = false;		
//var someTexture : Texture2D;
//guiTexture.texture = someTexture;
		

function Start(){
	pauseEnabled = false;
	Time.timeScale = 1;
	AudioListener.volume = 1;
	Screen.showCursor = false;
}

function Update(){

	//check if pause button (escape key) is pressed
	if(Input.GetKeyDown("escape"))
	{
	
		//check if game is already paused		
		if(pauseEnabled == true)
		{
			//unpause the game
			pauseEnabled = false;
			Time.timeScale = 1;				// Resumes the screen flow and unfreezes 
			AudioListener.volume = 1;
			Screen.showCursor = false;			
		}
		
		//else if game isn't paused, then pause it
		else if(pauseEnabled == false)
		{
			pauseEnabled = true;			
			AudioListener.volume = 0;		// Kills the sound.
			Time.timeScale = 0;				//freezes screen.
			Screen.showCursor = true; 		// shows the cursor.
		}
	}
}

private var showGraphicsDropDown = false;

function OnGUI(){

GUI.skin.box.font = pauseMenuFont;
GUI.skin.button.font = pauseMenuFont;
GUI.skin.label.font = pauseMenuFont;


	if(pauseEnabled == true)
	{
		
	
		
		//Make a background box
		GUI.Label(Rect(Screen.width /2 - 17,Screen.height /2 - 100,250,200), "Pause Menu");
		
		//Make Main Menu button
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 - 50,250,50), "Main Menu"))
		{
			Application.LoadLevel(mainMenuSceneName);// This will need changing to reflect the correct level.
		}
		
			//Make Change Graphics Quality button
			if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 ,250,50), "Change Graphics Quality"))
			{
			
			if(showGraphicsDropDown == false)
			{
				showGraphicsDropDown = true;
			}
			else
			{
				showGraphicsDropDown = false;
			}
		}
		
		
		if(showGraphicsDropDown == true){
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 ,250,50), "Fastest"))
			{
				QualitySettings.currentLevel = QualityLevel.Fastest;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 50,250,50), "Fast"))
			{
				QualitySettings.currentLevel = QualityLevel.Fast;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 100,250,50), "Simple"))
			{
				QualitySettings.currentLevel = QualityLevel.Simple;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 150,250,50), "Good"))
			{
				QualitySettings.currentLevel = QualityLevel.Good;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 200,250,50), "Beautiful"))
			{
				QualitySettings.currentLevel = QualityLevel.Beautiful;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 250,250,50), "Fantastic"))
			{
				QualitySettings.currentLevel = QualityLevel.Fantastic;
			}
			
			if(Input.GetKeyDown("escape"))
			{
				showGraphicsDropDown = false;
			}
		}
		
		//Make quit game button
		if (GUI.Button (Rect (Screen.width /2 - 100,Screen.height /2 + 50,250,50), "Quit Game"))
		{
			Application.Quit();
		}
	}
}