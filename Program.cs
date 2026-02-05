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
      while (input < 2 || inputstr == "")
      {
        Console.WriteLine("Please input a positive integer of at least 2.");
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
        myBoard.Step("X");

        if (myBoard.Result == "")
        {
          myBoard.Step("O");
        }
      }
    }
  }
}


