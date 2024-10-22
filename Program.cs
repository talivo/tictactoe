string[] grid = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
bool isPlayerTurn = true;
int numTurns = 0;

while (!CheckVictory() && numTurns != 9) {
    PrintGrid();

    if (isPlayerTurn) {
        Console.WriteLine("Player turn");
    } else {
        Console.WriteLine("Computer turn");
    }

    string choice = Console.ReadLine();
    if(grid.Contains(choice) && choice != "X" && choice != "0"){
        int gridIndex = Convert.ToInt32(choice) - 1;
        if (isPlayerTurn){
            grid[gridIndex] = "X";
        } else {
            grid[gridIndex] = "0";
        }
        numTurns++;
    }

    isPlayerTurn = !isPlayerTurn;
}

if(CheckVictory()) {
    PrintGrid();
    Console.WriteLine("Player wins");
} else{
    PrintGrid();
    Console.WriteLine("Tie");
}

bool CheckVictory() {
    bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
    bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
    bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
    bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
    bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
    bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
    bool diag1 = grid[0] == grid[4] && grid[4] == grid[8];
    bool diag2 = grid[6] == grid[4] && grid[4] == grid[2];

    return row1 || row2 || row3 || col1 || col2 || col3 || diag1 || diag2;
}

void PrintGrid() {

    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            Console.Write(grid[i * 3 + j] + "|");
        }
        Console.WriteLine();
        Console.WriteLine("------");
    }
}