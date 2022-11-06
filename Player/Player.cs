using Godot;
using System;

public class Player : KinematicBody2D
{
    private const float GRAVITY = 100;
    private const float MAX_SPEED = 70;

    private Vector2 velocity = Vector2.Zero;
    
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("move_left"))
        {
         
        }

        if (Input.IsActionPressed("move_right"))
        {
         
        }

        
        velocity.y += GRAVITY;

        MoveAndSlide(velocity);

    }

    
}
