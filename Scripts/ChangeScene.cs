using Godot;
using System;

public class ChangeScene : Container
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		GD.Print(GetChildren());

	}

	public void _on_NewGameButton_pressed()
	{
		GD.Print("hello");

		GetTree().ChangeScene("res://Scenes/Level0.tscn");

	}


	public void _on_ContinueButton_pressed()
	{
		GD.Print("hi");
	}

	public void _on_OptionsButton_pressed()
	{
		GD.Print("hfadshjkflllo");
	}


	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{

	}
}
