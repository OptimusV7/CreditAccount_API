using System.ComponentModel.DataAnnotations;

namespace KCBVooma.Models
{
    public class CreditCardModel
    {
        /*- Card id: the id of the card(not editable)
         - Card alias: personalised name of the card(editable)
         - Account id: account to which the card belongs(not editable)
         - Type of card: indicates if a card is virtual or physical(not editable)*/
        [Key]
        public int Id { get; set; }
        public string CardAlias { get; set; }
        public int AccountId { get; set; }
        public string TypeOfCard { get; set; }
    }
}
