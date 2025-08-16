package booking

import (
	"fmt"
	"time"
)

func Schedule(date string) time.Time {
	t, err := time.Parse("1/02/2006 15:04:05", date)
	if err != nil {
		panic(err)
	}
	return t
}

func HasPassed(date string) bool {
	t, err := time.Parse("January 2, 2006 15:04:05", date)
    if err != nil {
        panic(err)
    }

    return t.Before(time.Now())
}

func IsAfternoonAppointment(date string) bool {
    t, err := time.Parse("Monday, January 2, 2006 15:04:05", date)
    if err != nil {
        panic(err)
    }
	return 12 <= t.Hour() && t.Hour() < 18
}

func Description(date string) string {
    t, err := time.Parse("1/2/2006 15:04:05", date)
	if err != nil {
		panic(err)
	}
	return fmt.Sprintf("You have an appointment on %s", t.Format("Monday, January 2, 2006, at 15:04."))
}

func AnniversaryDate() time.Time {
	t, _ := time.Parse("2006-01-2", fmt.Sprintf("%d-09-15", time.Now().Year()))
	return t
}
