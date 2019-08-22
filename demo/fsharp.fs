type CustomerName(firstName, middleInitial, lastName) = 
    member this.FirstName = firstName
    member this.MiddleInitial = middleInitial
    member this.LastName = lastName  

type PrivateValueExample(seed) = 
    // private immutable value
    let privateValue = seed + 1

    // private mutable value
    let mutable mutableValue = 42

    // private function definition
    let privateAddToSeed input = 
        seed + input

    // public wrapper for private function
    member this.AddToSeed x = 
        privateAddToSeed x

    // public wrapper for mutable value
    member this.SetMutableValue x = 
        mutableValue <- x 
    
// test
let instance = new PrivateValueExample(42)
printf "%i" (instance.AddToSeed 2)
instance.SetMutableValue 43

type MethodExample() = 
    
    // recursive method without "rec" keyword
    member this.Fib x = 
        match x with
        | 0 | 1 -> 1
        | _ -> this.Fib (x-1) + this.Fib (x-2)