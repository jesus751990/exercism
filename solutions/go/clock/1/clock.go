package clock

import (
    "fmt"
    "math"
)

// Define the Clock type here.
type Clock struct {
    h int
    m int
}

func New(h, m int) Clock {
	c := Clock {
        h: h,
        m: m,
    }
    
	if c.m < 0 {
        c.h = h - (int(math.Abs(float64(m)) / 60) + 1)
        c.m = 60 - (int(math.Abs(float64(m))) % 60)
    } 
    
    if c.h < 0 {
        c.h = 24 - (int(math.Abs(float64(c.h))) % 24)         
    }

    if c.m > 59 || c.h >= 24 {
        c.h = (c.h + int(c.m / 60)) % 24
        c.m = c.m % 60
    }
    
    return c
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
