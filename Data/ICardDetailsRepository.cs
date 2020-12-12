using System.Threading.Tasks;
using CardDetailsGetter.Model;

namespace CardDetailsGetter.Data
{
    public interface ICardDetailsRepository
    {
        CardDetailString GetCardDetails(string cardNumber);
        Task<CardDetails> GetCardDetailsAsync(string cardNumber);
    }
}