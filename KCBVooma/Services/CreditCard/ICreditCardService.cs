using KCBVooma.Models;
using KCBVooma.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KCBVooma.Services.CreditCard
{
    public interface ICreditCardService
    {
        public List<CreditCardModel> GetCreditCardList();
        public CreditCardModel GetCardById(int Id);
        public AccountModel GetAccByCardId(int Id);
        public Task<int> UpdateCard(CreditCardVM creditCard);
        public Task<int> DeleteCard(int Id);
        public Task<int> AddCard(CreditCardModel creditCard);
    }
}
