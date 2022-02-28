using System;

Random randomizer = new Random();

int guesses = 0;
bool finished = false;
int secretNumber = randomizer.Next(1, 101);

//baseline communication
Console.WriteLine("Hello, why don't you guess a number between 1 and 100?");
Console.WriteLine("But first, type a difficulty level: Easy, Medium, Hard");
string difficulty = Console.ReadLine().ToLower();

//make sure difficulty is something we use
while (difficulty != "easy" && difficulty != "medium" && difficulty != "hard" && difficulty != "cheater") {
    Console.WriteLine("i SAAAIIID pick easy, medium, or hard.");
    difficulty = Console.ReadLine().ToLower();
}

//adjust guesses to difficulty
switch (difficulty) {
    
    case "easy":
        guesses = 8;
        break;
    
    case "medium":
        guesses = 6;
        break;

    case "hard":
        guesses = 4;
        break;

    case "cheater":
        guesses = -1;
        break;

    default:
        Console.WriteLine("How did you do this. YOu have BroRkRn MESDDEDSgSDg;hkjl...");
        break;
}

//while loop that handles game logic. Use the finished trigger to determine if we keep running.
while (!finished) {
    //this is how we check if we are cheating or not and provide the correc tmessage to user
    if (guesses > 0) {
    Console.Write($"Give me you guess, you have {guesses} left: ");
    } else {
        Console.Write($"Ges NumBER, u Hvae mANy GesES: ");
    }
    //grab the guess and determine if it is a usable response
    bool guessIsInt = int.TryParse(Console.ReadLine(), out int numberGuess);
    //guess logic if it is an integer the user put in
    if (guessIsInt) {
        if (numberGuess == secretNumber) {
            Console.WriteLine("You Done DiD It!");
            finished = true;
        } else {
            //logic for delivering message to user about their guess
            if (numberGuess > secretNumber) {
                Console.WriteLine("You guessed too HIGH");
            } else {
                Console.WriteLine("You guessed too LOW");
            }
            Console.WriteLine("you're a failure");
            //make sure we decrease guesses by 1
            guesses--;
        }
    } else { //message to use if they do not use an integer
        Console.WriteLine("Is it HTAT difficult to typ n a NUmber!??!");
        Console.WriteLine("One LESs GeSZ for U");
        guesses--;
    }

    //trigger the end of the game when guesses are done with when not playing cheater.
    //if guesses start below 0 (in cheater mode) we  will never activate this trigger.
    if (guesses == 0) {
        finished = true;
        Console.WriteLine("You Lost! Loser");
    }
}