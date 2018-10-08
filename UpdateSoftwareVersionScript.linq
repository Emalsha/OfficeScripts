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


var SoftwareVer = from ent in EntityObject 
					where ent.SoftwareVersionId == null
					select ent;
					
foreach (var epd in SoftwareVer)
{
	epd.SoftwareVersionId = Guid.Parse("4df45ee6-daca-e811-90f8-00155d1e2836");
	epd.CreatedById = Guid.Parse("c6f19016-258f-e711-90ea-00155d1e2836");
	epd.CreatedOn = DateTime.Parse("05.10.2018");
	
	UpdateObject(epd);
	SaveChanges();
} 