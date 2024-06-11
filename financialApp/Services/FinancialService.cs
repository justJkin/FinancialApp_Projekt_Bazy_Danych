using financialApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using financialApp.Models;

namespace financialApp.Services
{
    public class FinancialService
    {
        private readonly DataContext _context;

        public FinancialService(DataContext context)
        {
            _context = context;
        }

        public void CalculateUserBalance(int userId, DateTime startDate, DateTime endDate)
        {
            // Implementacja metody
        }

        public void GenerateUserFinancialReport(int userId, DateTime startDate, DateTime endDate)
        {
            // Implementacja metody
        }

        public decimal GetAverageMonthlySpendings(int userId)
        {
            var averageSpendings = _context.Transactions
                .Where(t => t.UserID == userId && t.Type == TransactionType.Spendings)
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .Select(g => g.Sum(t => t.Amount))
                .Average();

            return averageSpendings;
        }

        public IEnumerable<FinancialReportItem> GetFinancialReport(int userId, DateTime startDate, DateTime endDate)
        {
            var financialReport = _context.Transactions
                .Where(t => t.UserID == userId && t.Date >= startDate && t.Date <= endDate)
                .GroupBy(t => t.UserID)
                .Select(g => new FinancialReportItem
                {
                    UserID = g.Key,
                    TotalIncomes = g.Where(t => t.Type == TransactionType.Incomes).Sum(t => t.Amount),
                    TotalSpendings = g.Where(t => t.Type == TransactionType.Spendings).Sum(t => t.Amount),
                    Balance = g.Where(t => t.Type == TransactionType.Incomes).Sum(t => t.Amount) - g.Where(t => t.Type == TransactionType.Spendings).Sum(t => t.Amount)
                }).ToList();

            return financialReport;
        }
    }

    public class FinancialReportItem
    {
        public int UserID { get; set; }
        public decimal TotalIncomes { get; set; }
        public decimal TotalSpendings { get; set; }
        public decimal Balance { get; set; }
    }
}
