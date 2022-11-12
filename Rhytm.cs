using Godot;
using System;

public class Rhytm : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private float hi_vol = 0;
    private float lo_vol = -80;
    private float changettime = 0.5f;

    private Icon icon;
    
    private AudioStreamOGGVorbis _calm;
    private AudioStreamOGGVorbis _angy;
    private AudioStreamPlayer player_calm;
    private AudioStreamPlayer player_angy;

    private float time = 0;

    private float interval = 0.5f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        icon = GetNode<Icon>("Icon");
        
        _calm = ResourceLoader.Load<AudioStreamOGGVorbis>("res://Music/test_calm.ogg");
        _angy = ResourceLoader.Load<AudioStreamOGGVorbis>("res://Music/test_angy.ogg");

        player_calm = GetNode<AudioStreamPlayer>("calm");
        player_angy = GetNode<AudioStreamPlayer>("angy");

        player_calm.Stream = _calm;
        player_angy.Stream = _angy;

        player_calm.VolumeDb = hi_vol;
        player_angy.VolumeDb = lo_vol;

        player_calm.Play();
        player_angy.Play();


        float BPM = 120;
        float BPS = BPM / 60;
        float interval = 1 / BPS;
        GD.Print(interval);

        time = 0f;
    }

    
    
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        time += delta;
        
           /* GD.Print("======");
            GD.Print(player_angy.VolumeDb);
            GD.Print(player_calm.VolumeDb);
        */
        if (time > interval)
        {
            icon.Pulse();
            time %= interval;
            GetNode("../Player").Set("canDash", true);
            
        }

        if (Input.IsActionJustPressed("ui_up"))
        {
            changetrack(player_calm,lo_vol);
            changetrack(player_angy,hi_vol);
        }
        
        if (Input.IsActionJustPressed("ui_down"))
        {
            changetrack(player_calm,hi_vol);
            changetrack(player_angy,lo_vol);
        }
        
    }

    async void changetrack(AudioStreamPlayer player,float volume)
    {
            var tween = CreateTween();
            tween.TweenProperty(player, "volume_db", volume, changettime);
        
    }
    
}