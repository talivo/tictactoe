string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
bool isPlayerTurn = true;
int numTurns = 0;

// Player chooses desired symbol.
Console.WriteLine("Choose a symbol");
Console.WriteLine("For X, input X");
Console.WriteLine("For O, input O");
string userInputSymbol = Console.ReadLine();
string userSymbol;
string computerSymbol;

if (userInputSymbol == "x" || userInputSymbol == "X") {
    userSymbol = "X";
    computerSymbol = "O";
    Console.WriteLine($"You have chosen {userSymbol}.");
} else if (userInputSymbol == "o" || userInputSymbol == "O") {
    userSymbol = "O";
    computerSymbol = "X";
    Console.WriteLine($"You have chosen {userSymbol}.");
} else {
    Console.WriteLine("Incorrect input, try again.");
    return;
}

// Main game loop
while (CheckVictory() == null && numTurns < 9) {
    PrintGrid();

    if (isPlayerTurn) {
        Console.WriteLine("Player turn");
        string choice = Console.ReadLine();
        
        if (grid.Contains(choice) && choice != "X" && choice != "O") {
            int gridIndex = Convert.ToInt32(choice) - 1;

            // Place player symbol on the grid
            if (grid[gridIndex] != "X" && grid[gridIndex] != "O") {
                grid[gridIndex] = userSymbol;
                numTurns++;
            } else {
                Console.WriteLine("That spot is already taken, try again.");
                continue;
            }
        } else {
            Console.WriteLine("Invalid input, try again.");
            continue;
        }
    } else {
        Console.WriteLine("Computer turn");

        bool computerInput = false;
        var rand = new Random();

        while (!computerInput) {
            int computerGuess = rand.Next(1, 10);
            string choice = computerGuess.ToString();

            if (grid.Contains(choice) && choice != "X" && choice != "O") {
                int gridIndex = Convert.ToInt32(choice) - 1;
                
                // Place computer symbol on the grid
                grid[gridIndex] = computerSymbol;
                computerInput = true;
                numTurns++;
            }
        }
    }

    // Switch turns
    isPlayerTurn = !isPlayerTurn;
}


// Check for a win or tie
string winner = CheckVictory();
PrintGrid();
if (winner == userSymbol) {
    Console.WriteLine("Player wins!");
} else if (winner == computerSymbol) {
    Console.WriteLine("Computer wins!");
} else {
    Console.WriteLine("It's a tie!");
}

// Function to check victory
string CheckVictory() {
    // Check rows
    if (grid[0] == grid[1] && grid[1] == grid[2]) return grid[0];
    if (grid[3] == grid[4] && grid[4] == grid[5]) return grid[3];
    if (grid[6] == grid[7] && grid[7] == grid[8]) return grid[6];

    // Check columns
    if (grid[0] == grid[3] && grid[3] == grid[6]) return grid[0];
    if (grid[1] == grid[4] && grid[4] == grid[7]) return grid[1];
    if (grid[2] == grid[5] && grid[5] == grid[8]) return grid[2];

    // Check diagonals
    if (grid[0] == grid[4] && grid[4] == grid[8]) return grid[0];
    if (grid[6] == grid[4] && grid[4] == grid[2]) return grid[6];

    // No winner
    return null;
}

// Function to print the grid
void PrintGrid() {
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            Console.Write(grid[i * 3 + j] + "|");
        }
        Console.WriteLine();
        Console.WriteLine("------");
    }
}
