using SQLite4Unity3d;

public class topScores{

	[PrimaryKey, AutoIncrement]
	public int id { get; set;}
	public string name { get; set;}
	public int score { get; set;}

}