var Ai_Name : String = "";
var Ai_Number : String = "1";
var pauseMenuFont : Font;
private var pauseEnabled = false;	
var aTexture : Texture;	
var aTexture1 : Texture;	
var aTexture2 : Texture;	
var AI_Picker = 0;
var Menu_Chooser = 0;
private var optionsOn : boolean = true;
var goBack = 0;

		
function Start()
{
Screen.showCursor = true;	
}

function Update()
{

	
}

function AI_1()
{
GUI.DrawTexture(Rect(Screen.width /2.236 - 85 ,Screen.height /8,200,200), aTexture, ScaleMode.ScaleToFit, true, 1.50f);
}

function AI_2()
{
GUI.DrawTexture(Rect(Screen.width /2.236 - 85 ,Screen.height /8,200,200), aTexture1, ScaleMode.ScaleToFit, true, 1.50f);
}

function AI_3()
{
GUI.DrawTexture(Rect(Screen.width /2.236 - 85 ,Screen.height /8,200,200), aTexture2, ScaleMode.ScaleToFit, true, 1.50f);
}


function LoadLevel()
{
		Application.LoadLevel(1);	
}

		function OnGUI()
		{
			// Sets font for all used GUI items
			GUI.skin.box.font = pauseMenuFont;
			GUI.skin.button.font = pauseMenuFont;
			GUI.skin.label.font = pauseMenuFont;	
			AIandAppearance();
					
		}

		
		
		
		function AIandAppearance()
		{
		
		AI_1();
	
		Ai_Name = "AI Character: 1!";
		
		//If the first button is clicked, text is generated and AI function is ran
		if(GUI.Button(Rect(Screen.width /3,Screen.height /2 ,150,50), "AI Character 1"))
		{
			AI_Picker = 1;
			Ai_Name = "AI Character: 1!";
			Screen.showCursor = true;	
		}
		
		//If the second button is clicked, text is generated and AI function is ran
		if(GUI.Button(Rect((Screen.width /4 *2),Screen.height /2,150,50), "AI Character 3"))
		{
			AI_Picker = 2;
			Ai_Name = "AI Character: 3!";
			Screen.showCursor = true;	
		}
		
		//If the third button is clicked, text is generated and AI function is ran
		if(GUI.Button(Rect(Screen.width /2 - 160,Screen.height /2,150,50), "AI Character 2"))
		{
			AI_Picker = 3;
			Ai_Name = "AI Character: 2!";
			Screen.showCursor = true;	
			
		}
		
		
		
		if(GUI.Button(Rect(Screen.width /2 - 155,Screen.height /1.7,40,40), "1"))
		{
			Ai_Number = "1";
			Screen.showCursor = true;	
		}
		if(GUI.Button(Rect(Screen.width /2 - 105,Screen.height /1.7,40,40), "2"))
		{
			Ai_Number = "2";
			Screen.showCursor = true;	
		}
		if(GUI.Button(Rect(Screen.width /2 - 55,Screen.height /1.7,40,40), "3"))
		{
			Ai_Number = "3";	
			Screen.showCursor = true;	
		}
		
		
		// Loads the game.
		if (GUI.Button (Rect (Screen.width /2.236 - 25 ,Screen.height /2 + 150,80,50), "Play"))
		{
		Application.LoadLevel(0);	
		}
		
		
			
				if ( AI_Picker == 1)
				{
				AI_1();
				}
				
				if ( AI_Picker == 2)
				{
				AI_2();
				}
				
				if ( AI_Picker == 3)
				{
				AI_3();
				}
			
			// The  label for the name above the AI charcter.	
			GUI.Label(Rect(Screen.width /2 - 140,Screen.height /8,150,50), Ai_Name );
			//Label for AI number
			GUI.Label(Rect(Screen.width /2 - 90,Screen.height /2.4,150,50), Ai_Number );
			
			GUI.Label(Rect(Screen.width /2 - 130,Screen.height /2.59,150,50), "Number of AI" );
			
			
			
			if (GUI.Button(Rect(Screen.width /2 - 390,Screen.height /8.2,100,50), "Go Back" ))
			{
				goBack = 1;
			}
			
			if (goBack == 1)
			{
			
				Application.LoadLevel(4);
				
			}
		}



