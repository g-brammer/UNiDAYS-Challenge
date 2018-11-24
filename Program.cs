using System;
using Unidays_Challenge;

class Program
{
    static void Main()
    {
        PricingRule pricingRule = new PricingRule();

        pricingRule.createItem('A', new ItemPrice(8, 1, 8));
        pricingRule.createItem('B', new ItemPrice(12, 2, 20));
        pricingRule.createItem('C', new ItemPrice(4, 3, 10));
        pricingRule.createItem('D', new ItemPrice(7, 2, 7));
        pricingRule.createItem('E', new ItemPrice(5, 3, 10));

        UnidaysDiscountChallenge exampleOrder = new UnidaysDiscountChallenge(pricingRule);

        exampleOrder.addToBasket('B');
        exampleOrder.addToBasket('B');
        exampleOrder.addToBasket('B');
        exampleOrder.addToBasket('B');

        BasketResult result = exampleOrder.calculateTotalPrice();

        decimal totalPrice = result.getTotal();
        decimal deliveryCharge = result.getDeliveryCharge();
        decimal overallTotal = totalPrice + deliveryCharge;

        Console.WriteLine(totalPrice);
        Console.WriteLine(deliveryCharge);
        Console.WriteLine(overallTotal);
        Console.ReadKey();
    }
}

