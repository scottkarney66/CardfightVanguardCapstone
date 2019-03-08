

namespace DataAccessLayer.DataClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class VanguardCardsDO
    {
       public int CardID { get; set;}
       public string CardName { get; set;}
       public string CardEffect { get; set; }
       public string FlavorText { get; set; }
       public string Clan { get; set; }
       public string Power { get; set; }
       public string Race { get; set; }
       public string Grade { get; set; }
       public string Shield { get; set; }
       public string Critical { get; set; }
       public string Trigger { get; set; }
       public string Skill { get; set; }
       public string CardType { get; set; }
       public string Nation { get; set; }
       public int FK_DeckID { get; set; }
    }
}
