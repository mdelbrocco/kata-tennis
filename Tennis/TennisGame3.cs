using System;

namespace Tennis
{
  public class Player
  {
    public string Name { get; private set; }
    public int Points { get; private set; }

    public Player(string name)
    {
      Name = name;
      Points = 0;
    }

    public void AddPoint() => Points++;
  }

  public class TennisGame3 : ITennisGame
  {
    private readonly Player player1;
    private readonly Player player2;

    public TennisGame3(string player1Name, string player2Name)
    {
      player1 = new Player(player1Name);
      player2 = new Player(player2Name);
    }

    public string GetScore()
    {
      var p1 = player1.Points;
      var p2 = player2.Points;
      if ((p1 < 4 && p2 < 4) && (p1 + p2 < 6))
      {
        string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
        var score = p[p1];
        return (p1 == p2) ? score + "-All" : score + "-" + p[p2];
      }
      else
      {
        if (p1 == p2)
          return "Deuce";
        var playerInTheLead = p1 > p2 ? player1.Name : player2.Name;
        return ((p1 - p2) * (p1 - p2) == 1) ? "Advantage " + playerInTheLead : "Win for " + playerInTheLead;
      }
    }

    public void WonPoint(string playerName)
    {
      var player = (playerName == player1.Name ? player1 
                  : playerName == player2.Name ? player2 
                  : null) ?? throw new Exception($"Unknown player {playerName}");
      player.AddPoint();
    }
  }
}