using Godot;
using Godot.Collections;
using System;
using System.Linq;
using System.Reflection;

public partial class RecourcesInfo : HBoxContainer
{
	private Player _player;
	private readonly Type _playerType = typeof(Player);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<Player>("../Player");
		Array<Node> recources = GetChildren();

		foreach(var recource in recources)
		{
			if(recource is Label label)
			{
				label.Text = $"{label.Name}: {_playerType.GetProperty(label.Name).GetValue(_player)}";
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
