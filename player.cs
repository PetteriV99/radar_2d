using Godot;
using System;

public partial class player : Area2D
{
	[Export]
	public int speed = 400; // How fast the player will move (pixels/sec).
	public Vector2 screenSize; // Size of the game window.
	
	private Vector2 _velocity = new Vector2();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var target = GetGlobalMousePosition();
		_velocity = target - Position;
		
		if (Input.IsActionPressed("move"))
		{
			if (_velocity.Length() > speed * (float)delta)
			{
				_velocity = _velocity.Normalized() * speed;
			}

			Position += _velocity * (float)delta;
		}
	}
}
