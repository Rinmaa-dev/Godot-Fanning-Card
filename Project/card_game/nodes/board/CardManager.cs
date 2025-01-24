using Godot;
using System;
using System.Collections.Generic;
using Card_Game.resources;

public partial class CardManager : Node2D
{
	[Export] public int JumlahKartu = 1;
	
	[Export] public Curve CurvaDistribusiKartu;
	
	Marker2D _marker2D;
	
	public List<CardData> Hands = new List<CardData>();
	

	private string _cardNodePath = "res://nodes/card/Card.tscn";	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_marker2D = GetNode<Marker2D>("Marker2D");

		for (int i = 0; i < JumlahKartu; i++)
		{
			GetRandomCardData();
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SpawnCard()
	{
		Vector2 cardPosition = _marker2D.GlobalPosition;

		float offsetX = 900f; // sebagai jarak antara kartu pertama dan kartu terakhir
		float offsetY = 100f;
		
		PackedScene cardScene = (PackedScene)ResourceLoader.Load(_cardNodePath);
		
		foreach (CardData card in Hands)
		{
			// mengubah distribusi index kartu dari tengah
			float offsetIndex = card.index - (Hands[Hands.Count - 1].index / 2 );
			
			CardBase cardNode = cardScene.Instantiate<CardBase>() as CardBase;
			cardNode.Position = new Vector2(cardPosition.X + (offsetIndex * offsetX), 
				cardPosition.Y - (CurvaDistribusiKartu.Sample(Mathf.Abs(offsetIndex)) * offsetY) );
			
			cardNode.Rotation = offsetIndex;
			
			cardNode.CardData = card;
			GD.Print(offsetIndex);
			this.AddChild(cardNode);
		}
	}

	private void GetRandomCardData()
	{
		CardData cardData = new CardData();
		
		cardData.Id = GetRandomNumber(0, 1000);
		cardData.Cost = GetRandomNumber(0, 7);
		cardData.Value = GetRandomNumber(0, 5);
		cardData.CardType = GetRundomType();
		cardData.NameCard = $"Card_{cardData.Id}";
		cardData.CardDescription = $"Value of {cardData.Value}";
		cardData.index =  (float)Hands.Count / JumlahKartu;
		
		Hands.Add(cardData);

	}

	private CardType GetRundomType()
	{
		int rundom = GetRandomNumber(0, 3);

		if (rundom == 0)
		{
			return CardType.Attack;
		}
		else if (rundom == 1)
		{
			return CardType.Defense;
		}
		else if (rundom == 2)
		{
			return CardType.Special;
		}

		return CardType.Special;
	}

	private int GetRandomNumber(int min, int max)
	{
		Random random = new Random();
		return random.Next(min, max);
	}
}
