package clock

import "fmt"

// Define the Clock type here.
type Clock struct {
    h int
    m int
}

const (
    MinutesPerHours = 60
    MinutesPerDay = 1440
)

func New(h, m int) Clock {
    totalMinutes := h * MinutesPerHours + m
    totalMinutes %= MinutesPerDay
    if totalMinutes < 0 {
        totalMinutes += MinutesPerDay
    }
    return Clock {
        h: totalMinutes / MinutesPerHours,
        m: totalMinutes % MinutesPerHours,        
    }
}

func (c Clock) Add(m int) Clock {
	return New(c.h, c.m + m)
}

func (c Clock) Subtract(m int) Clock {
	return New(c.h, c.m - m)
}

func (c Clock) String() string {
	return fmt.Sprintf("%02d:%02d", c.h, c.m)
}
