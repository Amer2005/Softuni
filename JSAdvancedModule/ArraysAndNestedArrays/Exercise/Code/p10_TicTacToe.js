function solve(moves)
{
    function getSymbol(player)
    {
        return player == 1 ? "X" : "O";
    }

    function checkWinners(game)
    {
        if(game[0][0] == game[1][0] && game[1][0] == game[2][0])
        {
            if(game[0][0] != false)
            {
                return game[0][0];
            }
        }
        if(game[0][1] == game[1][1] && game[1][1] == game[2][1])
        {
            if(game[0][1] != false)
            {
                return game[0][1];
            }
        }
        if(game[0][2] == game[1][2] && game[1][2] == game[2][2])
        {
            if(game[0][2] != false)
            {
                return game[0][2];
            }
        }
        if(game[0][0] == game[0][1] && game[0][1] == game[0][2])
        {
            if(game[0][0] != false)
            {
                return game[0][0];
            }
        }
        if(game[1][0] == game[1][1] && game[1][1] == game[1][2])
        {
            if(game[1][0] != false)
            {
                return game[1][0];
            }
        }
        if(game[2][0] == game[2][1] && game[2][1] == game[2][2])
        {
            if(game[2][0] != false)
            {
                return game[2][0];
            }
        }
        if(game[0][0] == game[1][1] && game[1][1] == game[2][2])
        {
            if(game[0][0] != false)
            {
                return game[0][0];
            }
        }
        if(game[0][2] == game[1][1] && game[1][1] == game[2][0])
        {
            if(game[0][2] != false)
            {
                return game[0][2];
            }
        }

        return false;
    }

    let matrix =[[false, false, false],[false, false, false],[false, false, false]];    

    let turn = 1;
    //1 - X; -1 - O

    let round = 1;

    for(let i = 0;i < moves.length;i++)
    {
        let x = Number(moves[i][0]);
        let y = Number(moves[i][2]);

        if(matrix[x][y] !== false)
        {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        round++;

        matrix[x][y] = getSymbol(turn);

        turn = -turn;

        if(checkWinners(matrix) !== false)
        {
            console.log(`Player ${checkWinners(matrix)} wins!`);
            break;
        }

        if(round == 10)
        {
            console.log('The game ended! Nobody wins :(');
            break;
        }
    }

    for(let i = 0;i < matrix.length;i++)
    {
        console.log([...matrix[i]].join('\t'));
    }
}

solve(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]
);