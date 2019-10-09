using System;

/**
 * @author: Adheli
 */
class Team
{
    private int games_played;
    private int points;
    private string name;

    public Team(string name)
    {
        this.name = name;
    }
    public void Win()
    {
        this.games_played++;
        this.points += 3;
    }
    public void Draw()
    {
        this.games_played++;
        this.points++;
    }
    public void Loss()
    {
        this.games_played++;
    }
    public void PrintDetails()
    {
        Console.WriteLine("Name = {0}\nTotal Games = {1}\nTotal Points = {2}", this.ReadName(), this.ReadGamesPlayed(), this.ReadPoints());
    }
    public int ReadPoints()
    {
        return this.points;
    }
    public int ReadGamesPlayed()
    {
        return this.games_played;
    }
    public String ReadName()
    {
        return this.name;
    }



}

