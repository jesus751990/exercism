// Two-fer or 2-fer is short for two for one. One for you and one for me.
package twofer

import "fmt"

// ShareWith If the given name is "Alice", the result should be "One for Alice, one for me." If no name is given, the result should be "One for you, one for me."
func ShareWith(name string) string {
	switch {
    case name != "":
        return fmt.Sprintf("One for %s, one for me.", name)
    default:
        return "One for you, one for me."
    }
}
