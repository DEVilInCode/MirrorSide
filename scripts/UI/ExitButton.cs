using Godot;
using System;

public partial class ExitButton : Button
{
	private void OnPressed()
	{
		GetTree().Quit();
	}
	
}
