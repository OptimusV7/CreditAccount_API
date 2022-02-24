using KCBVooma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KCBVooma.Services.CreditCard
{
    public interface ICreditCardService
    {
        public List<CreditCardModel> GetCreditCardList();
        public CreditCardModel GetCardById(int Id);
        public Task<int> UpdateCard(CreditCardModel creditCard);
        public Task<int> DeleteCard(int Id);
        public Task<int> AddCard(CreditCardModel creditCard);
    }
}
