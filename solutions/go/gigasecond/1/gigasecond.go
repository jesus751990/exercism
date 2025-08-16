// gigasecond use seconds like unit of time
package gigasecond

// import path for the time package from the standard library
import "time"

// AddGigasecond add 1 GSec to input time
func AddGigasecond(t time.Time) time.Time {
    gigasec, _ := time.ParseDuration("1000000000s")

	return t.Add(gigasec)
}
