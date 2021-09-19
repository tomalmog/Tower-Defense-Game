using Godot;
using System;

public class Enemy : PathFollow2D
{

	int speed = 200;
	int hp = 10;

	public override void _Ready()
	{
		AddToGroup("enemies");
	}



	public override void _PhysicsProcess(float delta)
	{
		Offset += speed * delta;

		if (UnitOffset >= 1)
		{
			QueueFree();
		}

	}



	public void _on_Area2D_area_entered(Area2D area)
	{

		if (area.IsInGroup("bullets"))
		{


			hp -= (int)area.Get("damage");
			area.QueueFree();

			if (hp <= 0)
			{
				QueueFree();
			}

		}

	}



	/*    public override void _Process(float delta)
		{



		}*/
}
