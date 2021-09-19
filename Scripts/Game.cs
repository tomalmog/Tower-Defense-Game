using Godot;
using System;
using System.Collections.Generic;




/* TODO
 * 
 * 
 * Have space bar as an option to start round  //
 * Give round speed up option and make gear rotate faster if it's on
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
    bool waveStarted = false;
    float gameSpeedModifier = 1;
    int enemiesRemaing = 10;


    public override void _Ready()
    {

        int[] wave = { 5, 10 };
        waveInfo.AddRange(wave);




        enemyTimer = (Timer)GetNode("EnemySpawnTimer");
        //enemyTimer.Start();
        
    }

    public void _on_EnemySpawnTimer_timeout()
    {

        if (waveStarted)
        {
          
            var spawnedEnemy = enemyScene.Instance();
            Node path = GetNode("Map/Path");


            path.AddChild(spawnedEnemy);

        }

    }





    public void _on_Button_button_down()
    {
        /*        if (waveStarted)
                {
                    enemyTimer.Stop();
                    waveStarted = false;
                    GD.Print("Stopped");

                }

                else
                {
                    enemyTimer.Start();
                    waveStarted = true;
                    GD.Print("Started");
                }*/

        Input.ActionPress("toggleRound");

    }



/*    public void _on_Button_mouse_entered()
    {

        
        var animationPlayer = (AnimationPlayer)GetNode("Button/Sprite/GearSpinPlayer");
        animationPlayer.Play("GearSpin");
        animationPlayer.GetAnimation("GearSpin").Loop = true;


    }


    public void _on_Button_mouse_exited()
    {

        var animationPlayer = (AnimationPlayer)GetNode("Button/Sprite/GearSpinPlayer");
        animationPlayer.GetAnimation("GearSpin").Loop = false;
        GetNode("Button/Sprite").Set("rotation_degrees", 0);

    }*/













    /*    public async void createWave(int enemyCount, int spacing)
        {

            var timer = new Timer();
            timer.Connect("timeout", timer, "on_Timer_timeout");
            timer.WaitTime = 1;
            timer.OneShot = false;
            timer.Start();

        }*/






    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {

        if (Input.IsActionJustPressed("toggleRound"))
        {

            if (!waveStarted) { waveStarted = true; }
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
}
