<Query Kind="Statements">
  <Connection>
    <ID>03631303-3fa4-4c7b-8d58-f4e580b8e444</ID>
    <Persist>true</Persist>
    <Driver>AstoriaAuto</Driver>
    <Server>http://sdlntcorp02:88/Corporate/CampusNetCorporate.svc </Server>
    <UserName>dl</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAnJMFwQCZ+UCHbvo2kyWo9gAAAAACAAAAAAADZgAAwAAAABAAAAC7BHvqGmRvulxxeNtCpR3sAAAAAASAAACgAAAAEAAAAK/UlCHKvQq/FsnTXitiVSAQAAAAV1GYVLl/b1GE8V5DCRNBTBQAAACgnQKCoM9TWLgxbO/3X/P5pohFLA==</Password>
  </Connection>
</Query>


var localDt = (from domain in Domain
			   orderby domain.DomainNumber
			   select new { 
				   	domain.DomainNumber , 
					domain.DomainName , 
					domain.DomainDescription , 
					domain.Sorting
				}).ToList();
				
//localDt.Dump("List");

Util.WriteCsv(localDt,@"c:\domain.csv");

File.ReadAllText(@"c:\domain.csv").Dump("Read File");