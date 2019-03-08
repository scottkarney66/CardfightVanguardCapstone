namespace CardfightVanguardCapstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Vanguard_Decks
    {
        public Vanguard_Decks()
        {
            Decks = new DecksPO();
            AllDecks = new List<DecksPO>();
        }
        
       public DecksPO Decks { get; set; }
       public List<DecksPO> AllDecks { get; set; }
       public string ErrorMessage { get; set; }
    }
}