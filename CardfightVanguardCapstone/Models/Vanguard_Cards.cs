namespace CardfightVanguardCapstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Vanguard_Cards
    {
        public Vanguard_Cards()
        {
            Cards = new CardsPO();
            AllCards = new List<CardsPO>();
        }

        public CardsPO Cards { get; set; }
        public List<CardsPO> AllCards { get; set; }
        public string ErrorMessage { get; set; }
    }
}