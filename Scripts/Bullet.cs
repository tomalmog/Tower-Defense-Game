using Godot;
using System;

public class Bullet : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    int damage = 5;
    int speed = 800;
    Vector2 velocity;
    // Area2D target;
    WeakRef target;


    public override void _Ready()
    {
        //var newTarget = (Area2D)target.GetRef();
        //  enemyPosition = (newTarget.GlobalPosition - Position).Normalized() * speed;

        //  var newTarget = (Area2D)target.GetRef();
        //   velocity = (newTarget.GlobalPosition - Position).Normalized() * speed;

        //Rotation = velocity.Angle();

        

    }


    // Moves bullet towards target
    public override void _PhysicsProcess(float delta)
    {



        // Set values at first frame

        if (velocity == default(Vector2))
        {

            var newTarget = (Area2D)target.GetRef();
            velocity = (newTarget.GlobalPosition - Position).Normalized() * speed;

            Visible = true;


        }




        // Checks if enemy is still alive
        if (!(target.GetRef() == null))
        {
            Position += velocity * delta;
            Rotation = velocity.Angle();
        } 
        else
        {
            QueueFree();

        }


    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
