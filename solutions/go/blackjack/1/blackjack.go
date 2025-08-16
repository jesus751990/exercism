package blackjack

// ParseCard returns the integer value of a card following blackjack ruleset.
func ParseCard(card string) int {
    value:=0;
	switch card {
        case "ace": 
        	value =  11
        case "two": 
        	value =  2
        case "three": 
        	value =  3
        case "four": 
        	value =  4
        case "five": 
        	value =  5
        case "six": 
        	value =  6
        case "seven": 
        	value =  7
        case "eight": 
        	value =  8
        case "nine": 
        	value =  9
        case "ten": 
        	value =  10 
        case "jack": 
        	value =  10
        case "queen": 
        	value =  10
        case "king": 
        	value =  10
        default: 
        	value = 0
    }

    return value
}

// FirstTurn returns the decision for the first turn, given two cards of the
// player and one card of the dealer.
func FirstTurn(card1, card2, dealerCard string) string {
    const blackjack = 21;
    const twoAces = 22;
    const stand = "S";
    const hit = "H";
    const split = "P";
    const win = "W";
    
    handValue := ParseCard(card1) + ParseCard(card2);  
    dealerHandValue := ParseCard(dealerCard);

	action := "";

    switch {
        case handValue == twoAces:
        	action = split
        case handValue == blackjack && dealerHandValue < 10:
        	action = win
        case (handValue == blackjack && dealerHandValue >= 10) || (17 <= handValue && handValue <= 20) || (12 <= handValue && handValue <= 16 && dealerHandValue < 7):
        	action = stand
        default:
        	action = hit
    }

    return action;
}
