using Godot;

namespace Card_Game.resources;

public partial class CardBase : Node2D, ICard
{
    [Export] public CardData CardData { get; set; }
    
    public virtual void CreateCard()
    {
        Godot.GD.Print($"Kartu dengan Tipe {CardData.CardType} dibuat");
    }

    public void MouseEnterCardArea()
    {
       // Godot.GD.Print($"Mouse masuk ke area kartu {CardData.CardType}");
    }

    public void MouseExitCardArea()
    {
       // Godot.GD.Print($"Keluar masuk ke area kartu {CardData.CardType}");
    }

    public void InjecCardData(int id, string nameCard, string cardDescription,int cost, int value, CardType type)
    {
        CardData.Id = id;
        CardData.NameCard = nameCard;
        CardData.CardDescription = cardDescription;
        CardData.Cost = cost;
        CardData.Value = value;
        CardData.CardType = type;
        
    }
}