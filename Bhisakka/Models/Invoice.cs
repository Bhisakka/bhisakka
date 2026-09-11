using System;
using System.Collections.Generic;

namespace Bhisakka.Models
{
    internal class Invoice
    {
        private int invoiceId;
        private int? consultationId;
        private int patientId;
        private decimal consultationFee;
        private decimal discount;
        private string paymentMethod;
        private List<InvoiceLineItem> lineItems;

        public Invoice(int patientId)
        {
            this.patientId = patientId;
            consultationId = null;
            consultationFee = 0;
            discount = 0;
            paymentMethod = "Cash";
            lineItems = new List<InvoiceLineItem>();
        }

        public int GetInvoiceId()
        {
            return invoiceId;
        }

        public void SetInvoiceId(int value)
        {
            invoiceId = value;
        }

        public int? GetConsultationId()
        {
            return consultationId;
        }

        public void SetConsultationId(int? value)
        {
            consultationId = value;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public void SetPatientId(int value)
        {
            patientId = value;
        }

        public decimal GetConsultationFee()
        {
            return consultationFee;
        }

        public void SetConsultationFee(decimal value)
        {
            consultationFee = value;
        }

        public decimal GetDiscount()
        {
            return discount;
        }

        public void SetDiscount(decimal value)
        {
            discount = value;
        }

        public string GetPaymentMethod()
        {
            return paymentMethod;
        }

        public void SetPaymentMethod(string value)
        {
            paymentMethod = value;
        }

        public List<InvoiceLineItem> GetLineItems()
        {
            return lineItems;
        }

        public void SetLineItems(List<InvoiceLineItem> value)
        {
            lineItems = value;
        }

        public void AddLineItem(InvoiceLineItem item)
        {
            lineItems.Add(item);
        }

        public decimal GetSubtotal()
        {
            decimal subtotal = 0;
            for (int i = 0; i < lineItems.Count; i++)
            {
                subtotal += lineItems[i].GetLineTotal();
            }
            return subtotal;
        }

        public decimal GetTotalAmount()
        {
            return consultationFee + GetSubtotal() - discount;
        }
    }
}
