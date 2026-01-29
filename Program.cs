/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/

using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
  class Program
  {
    static void Step(string side, Board myBoard)
    {
      string inputstr = "";
      int input = 0;
      Console.WriteLine($"{side} to move:");
      inputstr = Console.ReadLine();

      while (myBoard.CheckValidInput(inputstr, side) != "true")
      {
        Console.WriteLine(myBoard.CheckValidInput(inputstr, side));
        myBoard.Print();
        Console.WriteLine($"{side} to move:");
        inputstr = Console.ReadLine();
      }

      myBoard.Print();

      if (myBoard.CheckWin(side) != "")  // if game is complete
      {
        Console.WriteLine(myBoard.CheckWin(side));
      }
    }
    static void Main(string[] args)
    {
      string inputstr = "";
      int input = 0;

      Console.WriteLine("Please input your desired board size:");
      inputstr = Console.ReadLine();

      if (Regex.IsMatch(inputstr, @"^\d+$") == true && inputstr != "") // check if input is an integer
      {
        input = Convert.ToInt32(inputstr);
      }
      while (Regex.IsMatch(inputstr, @"^\d+$") == false || inputstr == "")
      {
        Console.WriteLine("Please input an integer.");
        Console.WriteLine("Please input your desired board size:");
        inputstr = Console.ReadLine();
        if (Regex.IsMatch(inputstr, @"^\d+$") == true && inputstr != "")
        {
          input = Convert.ToInt32(inputstr);
        }
      }

      Board myBoard = new Board(input);

      Console.WriteLine("New game started.");
      myBoard.Print();

      while (myBoard.Result == "")
      {
        Step("X", myBoard);

        if (myBoard.Result == "")
        {
          Step("O", myBoard);
        }
      }
    }
  }
}


