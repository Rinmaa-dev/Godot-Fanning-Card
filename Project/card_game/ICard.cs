using Godot;
using System;
using Card_Game.resources;

public interface ICard
{
    CardData CardData { get; set; }
    
    void CreateCard();
    
    void MouseEnterCardArea();
    void MouseExitCardArea();
}
