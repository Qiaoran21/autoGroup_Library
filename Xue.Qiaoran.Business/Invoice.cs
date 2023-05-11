/*
 * Name: Qiaoran Xue
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-02-28
 * Updated: 2023-02-28
 */

using System;
using System.ComponentModel;

namespace Xue.Qiaoran.Business
{
    /// <summary>
    /// Supports the business process of creating an invoice.
    /// </summary>
    public abstract class Invoice
    {
        private decimal provincialSalesTaxRate;
        private decimal goodsAndServicesTaxRate;

        /// <summary>
        /// Occurs when the provincial sales tax rate of the Invoice changes. 
        /// </summary>
        public event EventHandler ProvincialSalesTaxRateChanged;

        /// <summary>
        /// Occurs when the goods and services tax rate of the Invoice changes.
        /// </summary>
        public event EventHandler GoodsAndServicesTaxRateChanged;

        /// <summary>
        /// Gets and sets the provincial sales tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the value is set to less than 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the value is set to greater than 1.
        /// </exception>
        public decimal ProvincialSalesTaxRate
        {
            get
            {
                return this.provincialSalesTaxRate;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }

                else if (value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");
                }
                
                if (this.provincialSalesTaxRate != value) 
                {
                    this.provincialSalesTaxRate = value;

                    OnProvincialSalesTaxRateChanged();
                }
            }
        }

        /// <summary>
        /// Gets and sets the goods and services tax rate.
        /// </summary>
        public decimal GoodsAndServicesTaxRate
        {
            get
            {
                return this.goodsAndServicesTaxRate;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }

                else if (value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");
                }
                
                if (this.goodsAndServicesTaxRate != value)
                {
                    this.goodsAndServicesTaxRate = value;

                    OnGoodsAndServicesTaxRateChanged();
                }
            }
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer. 
        /// </summary>
        public abstract decimal ProvincialSalesTaxCharged 
        { 
            get; 
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer. 
        /// </summary>
        public abstract decimal GoodsAndServicesTaxCharged
        {
            get;
        }

        /// <summary>
        /// Gets the subtotal of the invoice. 
        /// </summary>
        public abstract decimal SubTotal
        {
            get;
        }

        /// <summary>
        /// Gets the total of the invoice. 
        /// </summary>
        public decimal Total
        {
            get
            {
                return SubTotal + ProvincialSalesTaxCharged + GoodsAndServicesTaxCharged;
            }
        }

        /// <summary>
        /// Initializes an instance of Invoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServiceTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the provincial sales tax rate is less than 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the provincial sales tax rate is greater than 1.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the goods and services tax rate is less than 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the goods and services tax rate is greater than 1.
        /// </exception>
        public Invoice(decimal provincialSalesTaxRate, decimal goodsAndServiceTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be less than 0.");
            }

            if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be greater than 1.");
            }

            if (goodsAndServiceTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be less than 0.");
            }

            if (goodsAndServiceTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be greater than 1.");
            }

            this.ProvincialSalesTaxRate = provincialSalesTaxRate;
            this.GoodsAndServicesTaxRate = goodsAndServiceTaxRate;
        }

        /// <summary>
        /// Raises the ProvincialSalesTaxRateChanged event. 
        /// </summary>
        protected virtual void OnProvincialSalesTaxRateChanged()
        {
            if (ProvincialSalesTaxRateChanged != null)
            {
                ProvincialSalesTaxRateChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the GoodsAndServicesTaxRateChanged event. 
        /// </summary>
        protected virtual void OnGoodsAndServicesTaxRateChanged()
        {
            if (GoodsAndServicesTaxRateChanged != null)
            {
                GoodsAndServicesTaxRateChanged(this, new EventArgs());
            }
        }
    }
}