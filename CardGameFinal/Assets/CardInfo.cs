using System;

public struct CardInfo
{
	public string Name;
	public int Health;
	public int Tokens;
//	public CardType Type;

	public CardInfo (string n, int h, int t)
	{
		Name = n;
		Health = h;
		Tokens = t;
	}

//	public CardInfo (CardType t)
//	{
//		Type = t;
//		switch (t)
//		{
//		case CardType.Example1:
//			Name = "a";
//			Health = 1;
//			Tokens = 2;
//			break;
//		default:
//			Name = "Error";
//			Health = 0;
//			Tokens = 0;
//			break;
//		}
//	}

//	public enum CardType
//	{
//		None,
//		Example1,
//		Example2,
//		Example3
//	}
}

//Instead of Names.Add ("a"); etc just do
//Cards.Add(new CardInfo("a",1,2));
//I also have a framework for using enums instead built into this
//You can ignore it or play around with it as you want
