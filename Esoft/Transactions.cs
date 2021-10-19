namespace Esoft
{
    class Transactions
    {
        public static double SellerCount(int price, string type)
        {
            if (type == "House" || type == "Apartments")
                return 30000 + (price * 0.01);
            else
                return 30000 * (price * 0.02);
        }

        public static double BuyerCount(int price)
        {
            return price * 0.03;
        }

        public static double RealtorCount(double buyerCount, double sellerCount, int precentage)
        {
            if (precentage == 0)
                return (buyerCount + sellerCount) * 0.45;

            return (buyerCount + sellerCount) * precentage;
        }
    }
}
