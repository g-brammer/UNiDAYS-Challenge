# Unidays-Challenge
In my program I ended up using several different classes to try and find a solution.
I was able to provide some functionality, however there were issues which I couldn't figure out how to fix.

I was able to pass items into the basket using my addToBasket() method, and subsequently used my BasketResult class to calculate the delivery cost, based on the total price of the basket.

Initially I approached the problem by just trying to get the program to pass items in, and total up the order costs - without applying any discounts. This was successful.

It is when I tried to apply the discounts that I ran into problems. 
As is, this code will apply discounts when there is the correct number of certain items. For exmaple, the rule for item 'B' is 2 for £20, so if I tested the code with 2 B items in the basket, the code would correctly tell me the items cost £20, the delivery cost £7, and the total cost was £27. However, if I just added 1 B, then it would simply tell me it cost £0. And if I tried it with 3 Bs, then the discount would work on the first 2, but the last 1 would again be ignored, so the price it calculated would be the same as it was for just 2 Bs.

I believe the problem in my code must be within my calculateTotalPrice() method, and/or my applyDiscount() method.

I found this task very challenging and this was my best attempt. I think with some more time and experience I will be able to do something like this correctly.
