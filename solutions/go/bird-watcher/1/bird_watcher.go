package birdwatcher

// TotalBirdCount return the total bird count by summing
// the individual day's counts.
func TotalBirdCount(birdsPerDay []int) int {
    total := 0;
    for _, v := range birdsPerDay {
        total += v
 	}

    return total
}

// BirdsInWeek returns the total bird count by summing
// only the items belonging to the given week.
func BirdsInWeek(birdsPerDay []int, week int) int {
	start := (week - 1) * 7
    end := week * 7
    total := 0

    for i, v := range birdsPerDay {
        if (start <= i && i < end) {
            total += v
        }
    }

    return total
}

// FixBirdCountLog returns the bird counts after correcting
// the bird counts for alternate days.
func FixBirdCountLog(birdsPerDay []int) []int {
	for i, _ := range birdsPerDay {
        if (i % 2 == 0) {
            birdsPerDay[i] += 1
        }
    }

    return birdsPerDay
}
