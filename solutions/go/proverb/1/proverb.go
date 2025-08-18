// For want of a horseshoe nail, a kingdom was lost, or so the saying goes.
package proverb

import "fmt"

// Proverb given a list of inputs, generate the relevant proverb.
func Proverb(rhyme []string) []string {
    words := len(rhyme)
    proverb := make([]string, words)
    var message string
	for i := 0; i < words; i++ {
        switch {
        case (i + 1) == words:
            message = fmt.Sprintf("And all for the want of a %s.", rhyme[0])
		default: 
            message = fmt.Sprintf("For want of a %s the %s was lost.", rhyme[i], rhyme[i+1])            
        }
        proverb[i] = message
    }
    return proverb
}
