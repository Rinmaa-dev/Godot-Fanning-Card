using Godot;
using System;
using Card_Game.resources;
using Godot.Collections;

public partial class Card : CardBase
{
	private Dictionary<CardType, string> _baseCardDictionary = new Dictionary<CardType, string>()
	{
		{CardType.Attack, "blue"},
		{CardType.Defense, "green"},
		{CardType.Special, "purple"},
	};
	
	private Dictionary<CardType, string> _pictureCardDictionary = new Dictionary<CardType, string>()
	{
		{CardType.Attack, "axe"},
		{CardType.Defense, "Shield"},
		{CardType.Special, "scroll"},
	};
	
	private Label _costLabel;
	private Label _descriptionLabel;
	private Sprite2D _cardBase;
	private Sprite2D _cardPicture;
	
	public override void _Ready()
	{
		CreateCard();
	}
	
	public override void _Process(double delta)
	{
	}

	public override void CreateCard()
	{
		//base.CreateCard();
		
		_cardBase = GetNode<Sprite2D>("CardBase");
		_costLabel = GetNode<Label>("CardBase/Top/CostBase/CostLabel");
		_descriptionLabel = GetNode<Label>("CardBase/Buttom/DescriptionBase/DescriptionLabel");
		_cardPicture = GetNode<Sprite2D>("CardBase/Midle/CardPicture");
		
		_cardBase.Texture = ResourceLoader.Load<AtlasTexture>($"res://data/card_base_data/card_base_{_baseCardDictionary[CardData.CardType]}.tres");
		_cardPicture.Texture =
			ResourceLoader.Load<AtlasTexture>(
				$"res://data/card_pictures_data/card_picture_{_pictureCardDictionary[CardData.CardType]}.tres");
		_costLabel.Text = CardData.Cost.ToString();
		_descriptionLabel.Text = CardData.CardDescription;
	}
}
