using Godot;
using System;

public class Player : KinematicBody2D
{
    private const float GRAVITY = 100;
    private const float SPEED = 70;

    private Vector2 velocity = Vector2.Zero;
    
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        //GD.Print(IsOnFloor());
        velocity = Vector2.Zero;
        
        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= SPEED;
        }

        if (Input.IsActionPressed("move_right"))
        {
         
            velocity.x += SPEED;
        }

        
        velocity.y += GRAVITY;

        MoveAndSlide(velocity,Vector2.Up);

    }

    
}
