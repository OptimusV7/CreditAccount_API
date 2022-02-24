using System.ComponentModel.DataAnnotations;

namespace KCBVooma.Models
{
    public class AccountModel
    {
        /*- Account id: id of the account
         - Iban: iban of the account
         - bank Code: bank Code of the account
         - Customer id: client to whom the account belongs*/
        [Key]
        public int Id { get; set; }
        public int Iban { get; set; }
        public string BankCode { get; set; }
        public int CustomerId { get; set; }

    }
}
