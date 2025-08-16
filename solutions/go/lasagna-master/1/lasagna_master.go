package lasagna

func PreparationTime(layers []string, time int) int {
    totalLayers := len(layers)
    averageTime := 2

    if(time > 0) {
        averageTime = time
    }

    return averageTime * totalLayers
}

func Quantities(layers []string) (int, float64) {
    const noodlePerLayer = 50
    const saucePerLayer float64 = 0.2
	const noodleLayerKey = "noodles"
    const sauceLayerKey = "sauce"

    noodleQuantity := 0
    var sauceQuantity float64 = 0.0
    for _, v := range layers {
        if(v == noodleLayerKey){
            noodleQuantity += noodlePerLayer
        } else if (v == sauceLayerKey) {
            sauceQuantity += saucePerLayer
        }
    }

    return noodleQuantity, sauceQuantity
}

func AddSecretIngredient(friendsList []string, myList []string) {
    const lastItemKey = "?"
    myLastIngredient := myList[len(myList)-1]
    if(myLastIngredient == lastItemKey) {
    	lastFriendIngredient := friendsList[len(friendsList)-1]
        myList[len(myList)-1] = lastFriendIngredient
    }
}

func ScaleRecipe(quantities []float64, portions int) []float64 {
    slice := float64(portions) / 2.0
    scaledQuantities := make([]float64, len(quantities))

    for i, _ := range quantities {
        scaledQuantities[i] = quantities[i] * slice
    }

    return scaledQuantities
}
