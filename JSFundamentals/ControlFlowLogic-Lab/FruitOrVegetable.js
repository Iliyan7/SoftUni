function food(name){
    if(['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach'].filter(f => f == name)[0]) {
        console.log("fruit")
    }
    else if(['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley'].filter(v => v == name)[0]) {
        console.log("vegetable")
    }
    else {
        console.log("unknown")
    }
}