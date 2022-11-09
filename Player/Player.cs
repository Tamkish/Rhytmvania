using Godot;
using System;

public class Player : KinematicBody2D
{
    private const float GRAVITY = 100; //"constant" downwards acceleration
    private const float JUMP_VELOCITY = 400; //speed to apply when jumping

    private const float
        JUMP_DIVIDER = 2; //when is jump released, divide the velocity by this to jump lower (only if going up)

    private const float SPEED_UP = 100; //velocity to add when moving
    private const float SPEED_DOWN = 200f; //when player stops moving, this will decrease the horizontal speed;
    private const float MAX_SPEED = 700; //maximum horizontal speed;
    private const float COYOTE_TIME = 0.5f; // how long in seconds after falling can player coyote jump;
    private const float BUFFER_TIME = 0.5f; // how long in seconds before landing can player buffer jump;

    private Vector2 velocity = Vector2.Zero;
    private Timer coyote;


    public override void _Ready()
    {
        coyote = GetNode<Timer>("Coyote");
    }

    public override void _PhysicsProcess(float delta)
    {
        //Player can always move horizontally (if not, then change all of this i guess)
        if (IsOnWall())
        {
            velocity.x = 0;
        }

        bool acceleratedSideways = false;
        
        if (Input.IsActionPressed("move_left") && !Input.IsActionPressed("move_right"))
        {
            velocity.x -= SPEED_UP;
            velocity.x = Mathf.Clamp(velocity.x, -MAX_SPEED, MAX_SPEED);
            acceleratedSideways = true;
        }

        if (!Input.IsActionPressed("move_left") && Input.IsActionPressed("move_right"))
        {
            velocity.x += SPEED_UP;
            velocity.x = Mathf.Clamp(velocity.x, -MAX_SPEED, MAX_SPEED);
            acceleratedSideways = true;
        }


        //Slowing down
        if ((!acceleratedSideways)&&velocity.x != 0)
        {
            if (Mathf.Abs(velocity.x) > SPEED_DOWN)
            {
                velocity.x -= SPEED_DOWN * Mathf.Sign(velocity.x);
            }
            else
            {
                velocity.x = 0;
            }
        }


        /*
        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= SPEED;
        }

        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += SPEED;
        }


        if (!IsOnFloor())
        {
            velocity.y += GRAVITY;
        }
        else
        {
            velocity.y = 0;
        }
*/

        MoveAndSlide(velocity, Vector2.Up);


        GD.Print("==================");
        GD.Print("Coyote: " + coyote.TimeLeft);
    }
}