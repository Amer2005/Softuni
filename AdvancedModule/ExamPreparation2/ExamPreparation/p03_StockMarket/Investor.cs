using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }

        public int Count 
        { 
            get
            {
                return Portfolio.Count;
            }
        }

        public string FullName { get; set; }
         
        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;

                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if(!Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock stock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(stock);

            MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            if (!Portfolio.Any(x => x.CompanyName == companyName))
            {
                return null;
            }

            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
            {
                return null;
            }

            return Portfolio.OrderByDescending(x => x.MarketCapitalization).ToArray()[0];
        }
        
        public string InvestorInformation()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"The investor {FullName} with a broker {BrokerName} has stocks:" + Environment.NewLine);
            result.Append(String.Join(Environment.NewLine, Portfolio));

            return result.ToString();
        }
    }
}
