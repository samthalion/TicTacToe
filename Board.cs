using System;
using System.Runtime.InteropServices;
using Microsoft.Net.Http.Headers;
using System.Text.RegularExpressions;

class Board
{
  public string[][] board;
  public string Result
  {
    get; private set;
  }
  public int size
  {
    get; private set;
  }
  public Board(int n)
  {
    size = n;
    Result = "";
    board = new string[size][];
    for (int i = 0; i < n; i++)
    {
      string[] row = new string[size];
      for (int j = 0; j < n; j++)
      {
        row[j] = Convert.ToString(j + i * size + 1);
      }
      board[i] = row;
    }
  }

  public void Print()
  {
    for (int i = 0; i < size; i++)
    {
      string[] row = new string[size];
      string rowstring = "|";
      for (int j = 0; j < size; j++)
      {
        rowstring = string.Concat(rowstring, new string(' ', (size * size).ToString().Length - board[i][j].ToString().Length), board[i][j]);
        rowstring = string.Concat(rowstring, "|");
      }
      Console.WriteLine(rowstring);
    }
  }

  public bool Set(int x, string side)
  {
    for (int i = 0; i < size; i++)  // iterate through rows
    {
      if ((x - 1) / size == i)  // if input is on selected row
      {
        if (board[i][x - i * size - 1] == side)  // if input is X or Y
        {
          return true;
        }
        else
        {
          board[i][x - i * size - 1] = side;  // set input to side
          return false;
        }
      }
    }
    return false;
  }

  public string CheckWin(string side)
  {
    int intcell = 0;  // number of integers left in board
    int x = 0; // win along row
    int y = 0; // win along column
    int z1 = 0; // diagonal win 1
    int z2 = 0; // diagonal win 2
    for (int i = 0; i < size; i++)
    {
      x = 0;
      y = 0;
      for (int j = 0; j < size; j++) // checking for win along rows or columns
      {
        if (board[i][j] == side)
        {
          x++;
        }
        if (board[j][i] == side)
        {
          y++;
        }
        if (board[i][j] == "O" || board[i][j] == "X")  // number of filled in cells
        {
          intcell++;
        }
      }
      if (x == size || y == size)
      {
        Result = $"{side} wins the game!"; ;
      }
      if (board[i][i] == side)
      {
        z1++;
      }
      if (board[i][size - 1 - i] == side)
      {
        z2++;
      }
    }
    if (z1 == size || z2 == size)
    {
      Result = $"{side} wins the game!"; ;
    }
    if (intcell == size * size)
    {
      Result = "Draw :(";
    }
    return Result;
  }
  public string CheckValidInput(string inputstr, string side)
  {
    if (Regex.IsMatch(inputstr, @"^[\d]+$") == false || inputstr == "")
    {
      return "Please input an integer.";
    }
    else
    {
      int input = Convert.ToInt32(inputstr);
      if (input < 1 || input > size * size)
      {
        return $"Value must be between 1 and {size * size}.";
      }
      else if (Set(input, side))
      {
        return $"Space {input} is already taken!";
      }
    }
    return "true";
  }
}