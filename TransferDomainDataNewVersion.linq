<Query Kind="Program" />


public class Domain
{
	public int DomainNumber;
	public String DomainName;
	public String DomainDescription;
	public int Sorting;
}

void Main()
{
	List<Domain> sourceList = SourceDomainData();
	Console.WriteLine(sourceList);
	SendToDestination(sourceList);
}


// Define other methods and classes here
public List<Domain> SourceDomainData()
{
	String connectionString = new SqlConnectionStringBuilder()
									{
										DataSource = "SDLNTCORP02",
										InitialCatalog = "corporate",
										UserID = "campus",
										Password = "campus"
									}.ConnectionString;
	
	List<Domain> domainList = new List<Domain>();
	
	using(SqlConnection source = new SqlConnection(connectionString)){
		SqlCommand sourceCmd = new SqlCommand("SELECT DomainNumber,DomainName,DomainDescription,Sorting FROM cnc.Domain ORDER BY DomainNumber",source);
		source.Open();
		SqlDataReader sourceRead = sourceCmd.ExecuteReader();
		while(sourceRead.Read()){
			Domain domain = new Domain
									{
										DomainNumber = int.Parse(sourceRead["DomainNumber"].ToString()),
										DomainName = sourceRead["DomainName"].ToString(),
										DomainDescription = sourceRead["DomainDescription"].ToString(),
										Sorting = int.Parse(sourceRead["Sorting"].ToString()),
									};
			domainList.Add(domain);
		}

	}

	return domainList;
}

public void SendToDestination(List<Domain> objectList)
{
	String connectionString = new SqlConnectionStringBuilder()
								{
									DataSource = "PC-ERA", // Change source
									InitialCatalog = "TEST2", //Change database
									UserID = "testing", // Change Username 
									Password = "testing" // Change password
								}.ConnectionString;

	using (SqlConnection con = new SqlConnection(connectionString)){
		con.Open();
		SqlCommand cmd = new SqlCommand("INSERT INTO Domain(DomainNumber, DomainName, DomainDescription,Sorting) VALUES ( @DomainNumber, @DomainName , @DomainDescription , @Sorting)",con);
		cmd.CommandType = CommandType.Text;
		foreach (var domain in objectList)
		{
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@DomainNumber", domain.DomainNumber);
			cmd.Parameters.AddWithValue("@DomainName", domain.DomainName);
			cmd.Parameters.AddWithValue("@DomainDescription", domain.DomainDescription);
			cmd.Parameters.AddWithValue("@Sorting", domain.Sorting);
			
			//Uncomment before execute
			//cmd.ExecuteNonQuery();
		}
		
		Console.WriteLine("DONE ;) ");
		con.Close();
	}


}