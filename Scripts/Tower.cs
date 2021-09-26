using Godot;
using System;
using System.Collections.Generic;

public class Tower : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.


	PackedScene bulletScene = (PackedScene)GD.Load("res://Projectiles/Bullet.tscn");
	List<Area2D> enemiesInRange = new List<Area2D>();


	public override void _Ready()
	{
		
	}




	public void _on_Range_area_entered(Area2D area)
	{


		if (area.IsInGroup("enemies"))
		{
			
			enemiesInRange.Add(area);
		}


	}



	public void _on_Range_area_exited(Area2D area)
	{

		if (area.IsInGroup("enemies"))
		{

			enemiesInRange.Remove(area);
		}

	}



	// This is the projectile shooting function
	public void _on_TowerShootTimer_timeout()
	{

		// Check if there are enemies in range
		if (enemiesInRange.Count >= 1)
		{

			// Create new bullet and add it as a child of tower
			var shot = bulletScene.Instance();
			AddChild(shot);


			// Sets the target of the bullet as the first enemy to enter the tower's range
			var target = WeakRef(enemiesInRange[0]);
			shot.Set("target", target);
			shot.Set("position", GetNode("TowerCollisionShape").Get("position"));
			shot.Set("rotation", (enemiesInRange[0].Position - Position).Normalized().Angle());


		}
	}


	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
