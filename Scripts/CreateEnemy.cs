using Godot;
using System;

public class CreateEnemy : Path2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.

	private PathFollow2D enemyNode;
	private Sprite enemySprite;
	private Texture enemyTexture;




	public override void _Ready()
	{

		base._Ready();




/*		enemyTexture = (Texture)GD.Load("res://Resources/Textures/coalTexture.png");

		enemyNode = new PathFollow2D();
		enemySprite = new Sprite();
		enemySprite.Texture = enemyTexture;


		AddChild(enemyNode);
		enemyNode.AddChild(enemySprite);
		enemyNode.AddToGroup("enemies2");

	}

	public override void _Process(float delta)
	{
		enemyNode.Offset += 1;


		*/
	}
}
