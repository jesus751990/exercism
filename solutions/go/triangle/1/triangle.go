// Package triangle determine if a triangle is equilateral, isosceles, or scalene.
package triangle

// Notice KindFromSides() returns this type. Pick a suitable data type.
type Kind int

const (
    // Pick values for the following identifiers used by the test program.
    NaT Kind = 1// not a triangle
    Equ Kind = 2// equilateral
    Iso Kind = 3// isosceles
    Sca Kind = 4// scalene
)

// KindFromSides return the kind of triangle: not a triangle, equilateral, isosceles, or scalene.
func KindFromSides(a, b, c float64) Kind {
	var k Kind
    if a <= 0 || b <= 0 || c <= 0 || (a+b) < c || (b+c) < a || (a+c) < b {
        k = NaT
    } else {
        switch {
        case a == b && a == c:
        	k = Equ
        case a == b || a == c || b == c:
            k = Iso
        default:
            k = Sca
        }
    }
        
	return k
}
