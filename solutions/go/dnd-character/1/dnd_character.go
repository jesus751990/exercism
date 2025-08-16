package dndcharacter

import (
    "math/rand"
    "math"
)

type Character struct {
	Strength     int
	Dexterity    int
	Constitution int
	Intelligence int
	Wisdom       int
	Charisma     int
	Hitpoints    int
}

// Modifier calculates the ability modifier for a given ability score
func Modifier(score int) int {
    modifier := (float64(score) - 10.0) / 2.0
    roundDown := int(math.Floor(modifier))
    return roundDown
}

// Ability uses randomness to generate the score for an ability
func Ability() int {
    totalDices := 4
    diceFaces := 6
	dices := make([]int, totalDices)
    for i := 0; i < totalDices; i++ {
        dices[i] = rand.Intn(diceFaces) + 1 
    }
    lower := dices[0]
    total := 0
    for _, v := range dices {
        if v < lower {
            lower = v
        }
        total += v
    }
    return total - lower
}

// GenerateCharacter creates a new Character with random scores for abilities
func GenerateCharacter() Character {
	character := Character {
        Strength: Ability(),
        Dexterity: Ability(),
        Constitution: Ability(),
        Intelligence: Ability(),
        Wisdom: Ability(),
        Charisma: Ability(),
        Hitpoints: 10,
    }

	character.Hitpoints += Modifier(character.Constitution)
    
    return character
}
