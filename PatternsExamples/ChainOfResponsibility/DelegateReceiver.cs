using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.ChainOfResponsibility
{
    public class DelegateReceiver
    {
        // банковские переводы
        public bool BankTransfer { get; set; }
        // денежные переводы - WesternUnion, Unistream
        public bool MoneyTransfer { get; set; }
        // перевод через PayPal
        public bool PayPalTransfer { get; set; }
        public DelegateReceiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }
    public class Pay
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public void BankPaymentHandler(DelegateReceiver receiver)
        {
            if (receiver.BankTransfer == true)
                Notify?.Invoke("Выполняем банковский перевод");
            else if (receiver.PayPalTransfer == true)
                PayPalPaymentHandler(receiver);
        }

        public void PayPalPaymentHandler(DelegateReceiver receiver)
        {
            if (receiver.PayPalTransfer == true)
                Notify?.Invoke("Выполняем перевод через PayPal");
            else if (receiver.MoneyTransfer == true)
                MoneyPaymentHandler(receiver);
           
        }
        // переводы с помощью системы денежных переводов
        public void MoneyPaymentHandler(DelegateReceiver receiver)
        {
            if (receiver.MoneyTransfer == true)
                Notify?.Invoke("Выполняем перевод через системы денежных переводов"); 
        }

    }
}
