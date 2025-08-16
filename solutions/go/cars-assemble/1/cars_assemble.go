package cars

// CalculateWorkingCarsPerHour calculates how many working cars are
// produced by the assembly line every hour.
func CalculateWorkingCarsPerHour(productionRate int, successRate float64) float64 {
	return float64(productionRate) * successRate / 100.0;
}

// CalculateWorkingCarsPerMinute calculates how many working cars are
// produced by the assembly line every minute.
func CalculateWorkingCarsPerMinute(productionRate int, successRate float64) int {
    return int(CalculateWorkingCarsPerHour(productionRate, successRate) / 60);
}

// CalculateCost works out the cost of producing the given number of cars.
func CalculateCost(carsCount int) uint {
    const normalPrice = 10000;
    const reducedPrice = 95000;
    const carsForReducedPrice = 10;

    if carsCount < carsForReducedPrice {
        return uint(normalPrice * carsCount);
    } else {
        return uint((carsCount/10*reducedPrice) + (carsCount%10*normalPrice));
    }
}
