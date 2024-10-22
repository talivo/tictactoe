tasks for tomorrow
MAKE THE COMPUTER PLAY INDEPENDENTLY
DECLARE WHEN THE COMPUTER WINS

Console.WriteLine("Choose a symbol");
Console.WriteLine("For X, input X");
Console.WriteLine("For O, input O");
char userInputSymbol = char.Parse(Console.ReadLine());
char userSymbol;
char computerSymbol;

if(userInputSymbol == 'x' || userInputSymbol == 'X') {
    userSymbol = 'X';
    computerSymbol = 'O';
    Console.WriteLine($"You have chosen for {userSymbol}.");
} else if (userInputSymbol == 'o' || userInputSymbol == 'O') {
    userSymbol = 'O';
    computerSymbol = 'X';
    Console.WriteLine($"You have chosen for {userSymbol}.");
} else {
    Console.WriteLine("Incorrect input, try again.");
    return;
}