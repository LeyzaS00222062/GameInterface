namespace GameInterface.Services
{

    // Reworked code for InsuranceService
    public interface IDiscountService
    {
        double GetDiscount();
    }
    public class InsuranceService
    {
        private readonly IDiscountService _discountService;

        public InsuranceService(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public double CalcPremium(int age, string gameMode)
        {
            double premium = 0.0;

            if (gameMode == "Casual")
            {
                if (age >= 18 && age <= 30) 
                    premium = 5.0;
                else if (age >= 31) 
                    premium = 2.5;
            }
            else if (gameMode == "Hardcore")
            {
                if (age >= 10 && age <= 35) 
                    premium = 6.0;
                else if (age >= 36) 
                    premium = 5.0;
            }


            if (age >= 50)
            {
                double discount = _discountService.GetDiscount();
                premium = premium * discount;
            }

            if (premium > 0)
                return premium;
            else
                return 0.0; // Return 0 for invalid inputs
        }
    }

}
