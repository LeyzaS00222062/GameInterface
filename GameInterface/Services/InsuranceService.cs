namespace GameInterface.Services
{

    // Reworked code for InsuranceService
    public interface IDiscountService
    {
        double GetDiscount();
    }

    public class DiscountService : IDiscountService
    {
        public double GetDiscount() => 0.9; // 10% discount for age 50 and above
    }

    public class InsuranceService
    {
        private readonly DiscountService _discountService;

        public InsuranceService(DiscountService discountService)
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
                if (age >= 18 && age <= 35) 
                    premium = 6.0;
                else if (age >= 36) 
                    premium = 5.0;
            }


            if (age >= 50)
            {
                
                premium *= _discountService.GetDiscount(); // Apply discount for age 50 and above
            }

            
            return premium;
            
               
        }
    }

}
