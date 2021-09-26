using Godot;
using System;
using System.Collections.Generic;




/* TODO
 * 
 * 
 * Have space bar as an option to start round  //
 * Give round speed up option and make gear rotate faster if it's on //
 * 
 * 
 * Add UI for cash, lives etc, to the top of the screen
 * Add a place to buy towers on the right of the screen
 * 
 * 
 * Add towers that can be dragged from side of screen onto the map
 * Add tower upgrades
 * 
 * 
 * Add other enemies 
 * Add properties to enemies, lead, camo etc
 * 
 * 
 * 
 * 
 * 
 */





public class Game : Node2D
{


	List<int> waveInfo = new List<int>();
	Texture coalTexture = (Texture)GD.Load("res://Resources/Textures/coalTexture.png");
	PackedScene enemyScene = (PackedScene)GD.Load("res://Enemies/Enemy.tscn");
	Timer enemyTimer;
	List<Node> enemiesOnScreen = new List<Node>();
	bool waveStarted = false;
	float gameSpeedModifier = 1;

	int currentCash = 500;
   // int currentL


	public override void _Ready()
	{
		
	}

 


	public void _on_Button_button_down()
	{
		Input.ActionPress("toggleRound");
	}




	public async void createWave(int enemyCount, float[] spacing)
	{
		for(int i = 0; i < enemyCount; i++)
		{
			var t = new Timer();
			AddChild(t);
			t.WaitTime = spacing[i];
			t.OneShot = true;
			t.Start();


			var spawnedEnemy = enemyScene.Instance();
			Node path = GetNode("Map/Path");
			path.AddChild(spawnedEnemy);
			enemiesOnScreen.Add(spawnedEnemy);


			await ToSignal(t, "timeout");

		}

		waveStarted = false;
		gameSpeedModifier = 1;
	}






	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{

		if (Input.IsActionJustPressed("toggleRound"))
		{

			if (!waveStarted) 
			{ 
				waveStarted = true;
				createWave(10, new float[] { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f });
			}
			else 
			{
				if (gameSpeedModifier == 1) { gameSpeedModifier = 2; } 
				else{ gameSpeedModifier = 1; }
			}
		}



		Engine.TimeScale = gameSpeedModifier;

		if (waveStarted)
		{
			var animationPlayer = (AnimationPlayer)GetNode("Button/Sprite/GearSpinPlayer");
			animationPlayer.Play("GearSpin");
			animationPlayer.GetAnimation("GearSpin").Loop = true;
		}
		else
		{
			var animationPlayer = (AnimationPlayer)GetNode("Button/Sprite/GearSpinPlayer");
			animationPlayer.Stop();
			GetNode("Button/Sprite").Set("rotation_degrees", 0);
			//animationPlayer.GetAnimation("GearSpin").Loop = false;

		}


	}



	public override void _Process(float delta)
	{
		//base._Process(delta);


		var cashLabel = (Label)GetNode("UI/VBoxContainer/cashLabel");
		var livesLabel = GetNode("UI/VBoxContainer/livesLabel");

		//cashLabel.Text = cash.ToString();






	}






}
