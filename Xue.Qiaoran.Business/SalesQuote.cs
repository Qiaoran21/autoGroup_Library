/*
 * Name: Qiaoran Xue
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-02-27
 * Updated: 2023-02-27
 */

using System;
using System.CodeDom;
using System.ComponentModel;

namespace Xue.Qiaoran.Business
{
    /// <summary>
    /// Represents a car sales quote.
    /// </summary>
    public class SalesQuote
    {
        private decimal vehicleSalePrice;
        private decimal tradeInAmount;
        private decimal salesTaxRate;
        private Accessories accessoriesChosen;
        private ExteriorFinish exteriorFinishChosen;

        /// <summary>
        /// Occurs when the price of the vehicle being quoted on changes. 
        /// </summary>
        public event EventHandler VehiclePriceChanged;

        /// <summary>
        /// Occurs when the amount for the trade in vehicle changes.
        /// </summary>
        public event EventHandler TradeInAmountChanged;

        /// <summary>
        /// Occurs when the chosen accessories change.
        /// </summary>
        public event EventHandler AccessoriesChosenChanged;

        /// <summary>
        /// Occurs when the chosen exterior finish changes.
        /// </summary>
        public event EventHandler ExteriorFinishChosenChanged;

        /// <summary>
        /// Gets and sets the sale price of the vehicle.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the vehicle sale price is less than or equal to 0.
        /// </exception>
        public decimal VehicleSalePrice
        {
            get
            {
                return this.vehicleSalePrice;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than or equal to 0.");
                }
                
                if (this.vehicleSalePrice != value) 
                {
                    this.vehicleSalePrice = value;

                    OnVehiclePriceChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets and sets the trade in amount. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the trade in amount is less than 0.
        /// </exception>
        public decimal TradeInAmount
        {
            get
            {
                return this.tradeInAmount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                
                if (this.tradeInAmount != value) 
                {
                    this.tradeInAmount = value;

                    OnTradeInAmountChanged();
                }
            }
        }

        /// <summary>
        /// Gets and sets the accessories that were chosen. 
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">
        /// Occurs when the accessories chosen is not listed in the accessories enumeration. 
        /// </exception>
        public Accessories AccessoriesChosen
        {
            get
            {
                return this.accessoriesChosen;
            }

            set
            {
                if (!Enum.IsDefined(typeof(Accessories), value))
                {
                    InvalidEnumArgumentException exception;
                    exception = new InvalidEnumArgumentException("The value is an invalid enumeration value.");

                    throw exception;
                }

                if (this.accessoriesChosen != value) 
                {
                    this.accessoriesChosen = value;

                    OnAccessoriesChosenChanged();
                }
            }
        }

        /// <summary>
        /// Gets and sets the exterior finish that was chosen. 
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">
        /// Occurs when the exterior finish chosen is not listed in the exterior finish enumeration. 
        /// </exception>
        public ExteriorFinish ExteriorFinishChosen
        {
            get
            {
                return this.exteriorFinishChosen;
            }

            set
            {
                if (!Enum.IsDefined(typeof(ExteriorFinish), value))
                {
                    InvalidEnumArgumentException exception;
                    exception = new InvalidEnumArgumentException("The value is an invalid enumeration value.");

                    throw exception;
                }

                if (this.exteriorFinishChosen != value)
                {
                    this.exteriorFinishChosen = value;

                    OnExteriorFinishChosenChanged();
                }
            }
        }

        /// <summary>
        /// Gets the cost of accessories chosen. 
        /// </summary>
        public decimal AccessoryCost
        {
            get
            {
                decimal stereoSystem = 505.05m;
                decimal leatherInterior = 1010.10m;
                decimal computerNavigation = 1515.15m;

                // Costs of the different options of the accessories chosen.
                switch (accessoriesChosen)
                {
                    case Accessories.StereoSystem:
                        return stereoSystem;
                    case Accessories.LeatherInterior:
                        return leatherInterior;
                    case Accessories.StereoAndLeather:
                        return stereoSystem + leatherInterior;
                    case Accessories.ComputerNavigation:
                        return computerNavigation;
                    case Accessories.StereoAndNavigation:
                        return stereoSystem + computerNavigation;
                    case Accessories.LeatherAndNavigation:
                        return leatherInterior + computerNavigation;
                    case Accessories.All:
                        return stereoSystem + leatherInterior + computerNavigation;
                    case Accessories.None:
                        return 0;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Gets the cost of the exterior finish chosen.
        /// </summary>
        public decimal FinishCost
        {
            get
            {
                decimal standard = 202.02m;
                decimal pearlized = 404.04m;
                decimal custom = 606.06m;

                // Costs of the different options of the exterior finish chosen.
                switch (exteriorFinishChosen)
                {
                    case ExteriorFinish.Standard:
                        return standard;
                    case ExteriorFinish.Pearlized:
                        return pearlized;
                    case ExteriorFinish.Custom:
                        return custom;
                    case ExteriorFinish.None:
                        return 0;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Gets the sum of the cost of the chosen accessories and exterior finish.
        /// </summary>
        public decimal TotalOptions
        {
            get
            { 
                return Math.Round(AccessoryCost + FinishCost, 2); 
            }
        }

        /// <summary>
        /// Gets the sum of the vehicle’s sale price and the Accessory and Finish Cost. 
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                return Math.Round(vehicleSalePrice + AccessoryCost + FinishCost, 2);
            }
        }

        /// <summary>
        /// Gets the amount of tax to charge based on the subtotal.
        /// </summary>
        public decimal SalesTax
        {
            get
            {
                return Math.Round(salesTaxRate * SubTotal, 2);
            }
        }

        /// <summary>
        /// Gets the sum of the subtotal and taxes.
        /// </summary>
        public decimal Total
        {
            get
            {
                return SubTotal + SalesTax;
            }
        }

        /// <summary>
        /// Gets the result of subtracting the trade-in amount from the total.
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                return Math.Round(Total - tradeInAmount, 2);
            }
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in value, sales tax rate, accessories chosen and exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice">The selling price of the vehicle being sold.</param>
        /// <param name="tradeInAmount">The amount offered to the customer for the trade in of their vehicle.</param>
        /// <param name="salesTaxRate">The tax rate applied to the sale of a vehicle.</param>
        /// <param name="accessoriesChosen">The value of the chosen accessories.</param>
        /// <param name="exteriorFinishChosen">The value of the chosen exterior finish.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the vehicle sale price is less than or equal to 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the trade in amount is less than 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the sales rate is less than 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the sales tax rate is greater than 1.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        /// Occurs when the accessories chosen is an invalid argument. 
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        /// Occurs when the finish chosen is an invalid argument. 
        /// </exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate, Accessories accessoriesChosen, ExteriorFinish exteriorFinishChosen)
        {
            if(vehicleSalePrice <=0)
            {
                throw new ArgumentOutOfRangeException("vehicleSalePrice", "The argument cannot be less than or equal to 0.");
            }

            if (tradeInAmount < 0)
            {
                throw new ArgumentOutOfRangeException("tradeInAmount", "The argument cannot be less than 0.");
            }

            if (salesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be less than 0.");
            }

            if (salesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be greater than 1.");
            }

            if(!Enum.IsDefined(typeof(Accessories), accessoriesChosen))
            {
                throw new InvalidEnumArgumentException("The argument is an invalid enumeration value.");
            }

            if (!Enum.IsDefined(typeof(ExteriorFinish), exteriorFinishChosen))
            {
                throw new InvalidEnumArgumentException("The argument is an invalid enumeration value.");
            }

            this.VehicleSalePrice = vehicleSalePrice;
            this.TradeInAmount = tradeInAmount;
            this.salesTaxRate = salesTaxRate;
            this.AccessoriesChosen = accessoriesChosen;
            this.ExteriorFinishChosen = exteriorFinishChosen;
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in amount, sales tax rate, no accessories chosen and no exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice">The selling price of the vehicle being sold.</param>
        /// <param name="tradeInAmount">The amount offered to the customer for the trade in of their vehicle.</param>
        /// <param name="salesTaxRate">The tax rate applied to the sale of a vehicle.</param>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate)
            : this(vehicleSalePrice, tradeInAmount, salesTaxRate, Accessories.None, ExteriorFinish.None)
        {

        }

        /// <summary>
        /// Raises the VehiclePriceChanged event.
        /// </summary>
        protected virtual void OnVehiclePriceChanged()
        {
            if (VehiclePriceChanged != null)
            {
                VehiclePriceChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the TradeInAmountChanged event. 
        /// </summary>
        protected virtual void OnTradeInAmountChanged()
        {
            if (TradeInAmountChanged != null)
            {
                TradeInAmountChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the AccessoriesChosenChanged event.
        /// </summary>
        protected virtual void OnAccessoriesChosenChanged()
        {
            if (AccessoriesChosenChanged != null)
            {
                AccessoriesChosenChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the ExteriorFinishChosenChanged event. 
        /// </summary>
        protected virtual void OnExteriorFinishChosenChanged()
        {
            if (ExteriorFinishChosenChanged != null)
            {
                ExteriorFinishChosenChanged(this, new EventArgs());
            }
        }
    }
}