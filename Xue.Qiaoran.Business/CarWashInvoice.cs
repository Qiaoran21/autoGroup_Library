/*
 * Name: Qiaoran Xue
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-02-28
 * Updated: 2023-02-28
 */
using System;

namespace Xue.Qiaoran.Business
{
    /// <summary>
    /// Supports the business process of creating an invoice for the car wash department. 
    /// </summary>
    public class CarWashInvoice : Invoice
    {
        private decimal packageCost;
        private decimal fragranceCost;

        /// <summary>
        /// Occurs when the package cost changes. 
        /// </summary>
        public event EventHandler PackageCostChanged;

        /// <summary>
        /// Occurs when the fragrance cost changes. 
        /// </summary>
        public event EventHandler FragranceCostChanged;

        /// <summary>
        /// Gets and sets the amount charged for the chosen package. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the cost is less than 0.
        /// </exception>
        public decimal PackageCost
        {
            get
            {
                return this.packageCost;
            }

            set
            {
                if (value < 0)
                {
                    ArgumentOutOfRangeException exception = new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                    throw exception;
                }
                
                if (this.packageCost != value) 
                {
                    this.packageCost = value;

                    OnPackageCostChanged();
                }
            }
        }

        /// <summary>
        /// Gets and sets the amount charged for the chosen fragrance. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the cost is less than 0.
        /// </exception>
        public decimal FragranceCost
        {
            get
            {
                return this.fragranceCost;
            }

            set
            {
                if (value < 0)
                {
                    ArgumentOutOfRangeException exception = new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                    throw exception;
                }
                
                if (this.fragranceCost != value)
                {
                    this.fragranceCost = value;

                    OnFragranceCostChanged();
                }
            }
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer. 
        /// </summary>
        public override decimal ProvincialSalesTaxCharged
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public override decimal GoodsAndServicesTaxCharged
        {
            get
            {
                return Math.Round(SubTotal * GoodsAndServicesTaxRate, 2);
            }
        }

        /// <summary>
        /// Gets the subtotal of the Invoice. 
        /// </summary>
        public override decimal SubTotal
        {
            get
            {
                return PackageCost + FragranceCost;
            }
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods and services tax rates. 
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate) 
            : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
           
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods, services tax rate, package cost and fragrance cost.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer. </param>
        /// <param name="packageCost">The cost of the chosen package.</param>
        /// <param name="fragranceCost">The cost of the chosen fragrance.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the package cost is less than 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the fragrance cost is less than 0.
        /// </exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate, decimal packageCost, decimal fragranceCost) 
            : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (packageCost < 0)
            {
                throw new ArgumentOutOfRangeException("packageCost", "The argument cannot be less than 0.");
            }

            if (fragranceCost < 0)
            {
                throw new ArgumentOutOfRangeException("fragranceCost", "The argument cannot be less than 0.");
            }
            
            this.PackageCost = packageCost;
            this.FragranceCost = fragranceCost;
        }

        /// <summary>
        /// Raises the PackageCostChanged event.
        /// </summary>
        protected virtual void OnPackageCostChanged()
        {
            if (PackageCostChanged != null)
            {
                PackageCostChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the FragranceCostChanged event. 
        /// </summary>
        protected virtual void OnFragranceCostChanged()
        {
            if (FragranceCostChanged != null)
            {
                FragranceCostChanged(this, new EventArgs());
            }
        }
    }
}