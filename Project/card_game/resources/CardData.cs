using Godot;

namespace Card_Game.resources;

[GlobalClass][Tool]
public partial class CardData : Resource
{
	[Export]
	public int Id {set;get;}
	[Export]
	public string NameCard {set;get;}
	[Export]
	public string CardDescription {set;get;}
	[Export]
	public int Cost {set;get;}
	[Export]
	public int Value {set;get;}
	[Export]
	public CardType CardType {set;get;}

	public float index {set;get;}
	
	
	public CardData(int id, string nameCard, string description, int cost, int value, CardType cardType)
	{
		Id = id;
		NameCard = nameCard;
		CardDescription = description;
		Cost = cost;
		Value = value;
		CardType = cardType;
		index = 0f;
	}
	
	public CardData() : this(0, "", "", 0, 0, CardType.Attack) { }
	
}