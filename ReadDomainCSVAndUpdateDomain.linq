<Query Kind="Statements">
  <Connection>
    <ID>d9862d5d-244e-4790-a2a1-e0c96a201f7e</ID>
    <Persist>true</Persist>
    <Driver>AstoriaAuto</Driver>
    <Server>http://localhost:8681/CampusNetCorporate.svc/</Server>
    <UserName>emalsha.rasad</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAVPhd00YTH0y5H0GHZ2UYMwAAAAACAAAAAAADZgAAwAAAABAAAACg+7NhME2wEohDZhJTNWuUAAAAAASAAACgAAAAEAAAAKtrw4d6ujSplOPSDyCoup4QAAAAAJjk7fOKnwu3zHWZ5AzTjBQAAADcxj6nflxQEzA0uAjUF2iLfdk3Lw==</Password>
  </Connection>
</Query>

var data = File.ReadAllLines(@"c:\domain.csv").Skip(1);

var formatedData = from line in File.ReadAllLines(@"c:\domain.csv").Skip(1)
				   let col = line.Split(',')
				   select new Domain { 
				   				DomainNumber = int.Parse(col[0]),
				   				DomainName = col[1],
								DomainDescription = col[2],
								Sorting = int.Parse(col[3]),
				   				};

formatedData.Dump();
foreach (Domain dom in formatedData)
{
	AddObject("Domain",dom);
}
//Uncomment below before do transaction.
//SaveChanges();

