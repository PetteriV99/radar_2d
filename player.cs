using Godot;

public partial class player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;

	private Vector2 _target;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("click"))
		{
			_target = GetGlobalMousePosition();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Position.DirectionTo(_target) * Speed;
		LookAt(_target);
		if (Position.DistanceTo(_target) > 10)
		{
			MoveAndSlide();
		}
	}
	
	public override void _Ready()
	{
		_target = Position;
	}
	
	public override void _Process(double delta)
	{
	}
}
