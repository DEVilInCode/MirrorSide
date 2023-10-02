using Godot;
using System;

public partial class Player : Node
{
	private int _level;
	private int _gold;
	private int _crystals;
	private int _credits;

	public int Level {
		get { return _level; }
	}

	public int Gold {
		get { return _gold; }
		set {
			if(value < 0)
				throw new Exception("Wrong gold value");
			else
				_gold = value;
		}
	}

	public int Crystals {
		get { return _crystals; }
		set {
			if(value < 0)
				throw new Exception("Wrong crystals value");
			else
				_gold = value;
		}
	}

	public int Credits {
		get { return _credits; }
		set {
			if(value < 0)
				throw new Exception("Wrong credits value");
			else
				_gold = value;
		}
	}
}
