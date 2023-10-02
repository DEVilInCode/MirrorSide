using Godot;
using System;

public partial class PasswordTextBox : LineEdit
{
	private int _minvalue=8;

	private void OnTextChanged(string text)
	{
		if(text.Length<_minvalue){
			GD.Print("The password is too small. Password must be over 8 symbols");
		}
			
	}
	
}


