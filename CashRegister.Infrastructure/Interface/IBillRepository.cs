using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure.Interface
{
    public interface IBillRepository
    {
        bool CreateNewBull(Bill bill);
        bool DeleteBill(Bill bill);
        Task<List<Bill>> GetAllBills();
        Task<Bill> GetBillByBillNumber(string billNumber);
        bool Save();
        bool UpdateBill(Bill bill);

        bool CheckIfBillExists(string billNumber);
    }
}