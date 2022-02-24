using KCBVooma.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KCBVooma.Services.CreditCard
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CreditCardService> _logger;

        public CreditCardService(ApplicationDbContext applicationDbContext, ILogger<CreditCardService> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }
        public async Task<int> AddCard(CreditCardModel creditCard)
        {
            var cc = new CreditCardModel
            {
                AccountId = creditCard.AccountId,
                CardAlias = creditCard.CardAlias,
                TypeOfCard = creditCard.TypeOfCard,
            };
            _context.CreditCards.Add(cc);
            var results = await _context.SaveChangesAsync();
            if (results > 0)
            {
                _logger.LogInformation(results.ToString());
            }
            _logger.LogInformation(results.ToString());
            return 200;
        }

        public async Task<int> DeleteCard(int Id)
        {
            var ccdata = _context.CreditCards.FirstOrDefault(x => x.Id == Id);
            if (ccdata != null)
            {
                _context.CreditCards.Remove(ccdata);
                return await _context.SaveChangesAsync();
            }
            return 400;
        }

        public CreditCardModel GetCardById(int Id)
        {
            return _context.CreditCards.Where(x => x.Id == Id).ToList().SingleOrDefault();
        }

        public List<CreditCardModel> GetCreditCardList()
        {
            var cclist = (from CreditCard in _context.CreditCards
                           select new CreditCardModel
                           {
                               AccountId = CreditCard.AccountId,
                               CardAlias = CreditCard.CardAlias,
                               TypeOfCard = CreditCard.TypeOfCard,
                               Id = CreditCard.Id                            
                               
                           }).ToList();
            return cclist;
        }

        public async Task<int> UpdateCard(CreditCardModel creditCard)
        {
            var ccdata = _context.CreditCards.FirstOrDefault(x => x.Id == creditCard.Id);
            if (ccdata != null)
            {
                ccdata.AccountId = creditCard.AccountId;
                ccdata.CardAlias = creditCard.CardAlias;
                ccdata.TypeOfCard = creditCard.TypeOfCard;

                return await _context.SaveChangesAsync();
            }
            return 400;
        }

        
    }
}
