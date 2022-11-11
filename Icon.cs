using Godot;
using System;

public class Icon : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public async void Pulse()
    {
        Scale = Vector2.One * 2;
        await ToSignal(GetTree().CreateTimer(0.1f), "timeout");
        Scale = Vector2.One;
    }
}
//test test editing test