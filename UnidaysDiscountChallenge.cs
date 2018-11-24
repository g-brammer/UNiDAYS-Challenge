using System.Collections.Generic;
using System.Linq;

namespace Unidays_Challenge
{
    class UnidaysDiscountChallenge
    {        
        List<char> basket = new List<char>();   //list of items in the order

        PricingRule pricingRule;   

        public UnidaysDiscountChallenge(PricingRule pricingRule)    //pricing rules constructor for UnidaysDiscountChallenge class
        {
            this.pricingRule = pricingRule;
        }

        public void addToBasket(char item)  //method to add items to basket
        {
            basket.Add(item);            
        }

        public BasketResult calculateTotalPrice()    //method to calc total items price + delivery price
        {
            decimal total = 0;            
            foreach (char item in basket)   //iterates through each item in the basket list, adding relevant price to total for each item in basket
            {
                total += pricingRule.getItem(item).getPrice();
            }

            foreach (var itemOccurence in basket.GroupBy(i => i))    //looks through basket and groups itmes with same key so that discount can be applied - doesn't work.
            {
                total -= pricingRule.getItem(itemOccurence.Key).applyDiscount(itemOccurence.Count());                              
            }

            return new BasketResult(total, (total >= 50 || total == 0) ? 0 : 7);  
        }
    }

    public class BasketResult   //public so instances can be created anywhere
    {
        private decimal total;
        private decimal deliveryCharge;

        public decimal getTotal()   //method to access total price
        {
            return this.total;
        }
        public decimal getDeliveryCharge()  //method to acces delivery charge
        {
            return this.deliveryCharge;
        }
        public BasketResult(decimal total, decimal deliveryCharge)  //constructor for BasketResult class. Parameters are total cost of items(After discount), and delivery charge
        {
            this.total = total;
            this.deliveryCharge = deliveryCharge;
        }
    }    

    class PricingRule
    {
        Dictionary<char, ItemPrice> items = new Dictionary<char, ItemPrice>();  //lists items as chars, with a value (ItemPrice) assigned to each one

        public ItemPrice getItem(char item)
        {
            ItemPrice itemPrice;
            items.TryGetValue(item, out itemPrice);
            return itemPrice;
        }

        public void createItem(char item, ItemPrice itemPrice)  
        {
            items.Add(item, itemPrice);
        }
    }

    class ItemPrice
    {
        private decimal price;
        private int itemQuantity;
        private decimal discountPrice;

        public ItemPrice(decimal price, int itemQuantity, decimal discountPrice)    //constructor for ItemPrice class, sets price, items needed for discount to be applied, and price after discount
        {
            this.price = price;
            this.itemQuantity = itemQuantity;
            this.discountPrice = discountPrice;
        }

        public decimal getPrice()   //method to access price
        {
            return this.price;
        }

        public decimal applyDiscount(int itemQuantity)  //method which applies discount
        {
            int numberOfDiscounts = itemQuantity / this.itemQuantity;   //using "/" gets rid of remainder
            return (price * itemQuantity) - (discountPrice * numberOfDiscounts);
        }     
    }
}