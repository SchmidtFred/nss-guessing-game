using System;

Random randomizer = new Random();

int guesses = 0;
bool finished = false;
int secretNumber = randomizer.Next(1, 101);


Console.WriteLine("Hello, why don't you guess a number between 1 and 100?");
Console.WriteLine("But first, type a difficulty level: Easy, Medium, Hard");
string difficulty = Console.ReadLine().ToLower();

while (difficulty != "easy" && difficulty != "medium" && difficulty != "hard" && difficulty != "cheater") {
    Console.WriteLine("i SAAAIIID pick easy, medium, or hard.");
    difficulty = Console.ReadLine().ToLower();
}

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

while (!finished) {
    if (guesses > 0) {
    Console.Write($"Give me you guess, you have {guesses} left: ");
    } else {
        Console.Write($"Ges NumBER, u Hvae mANy GesES: ");
    }
    bool guessIsInt = int.TryParse(Console.ReadLine(), out int numberGuess);
    if (guessIsInt) {
        if (numberGuess == secretNumber) {
            Console.WriteLine("You Done DiD It!");
            finished = true;
        } else {
            if (numberGuess > secretNumber) {
                Console.WriteLine("You guessed too HIGH");
            } else {
                Console.WriteLine("You guessed too LOW");
            }
            Console.WriteLine("you're a failure");
            guesses--;
        }
    } else {
        Console.WriteLine("Is it HTAT difficult to typ n a NUmber!??!");
        Console.WriteLine("One LESs GeSZ for U");
        guesses--;
    }

    if (guesses == 0) {
        finished = true;
        Console.WriteLine("You Lost! Loser");
    }
}