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

var numberOfEntry = 1;
var domainName = "Leistungen entwickeln";
var configObjectTypeName = "Liste";

var getDomainId = (from _d in Domain
					where _d.DomainName == domainName
					select _d).First().Id;
					
var getConfigObjectTypeId = (from _c in ConfigObjectType 
								where _c.DataTypeName == configObjectTypeName
								select _c).First().Id;
					
for(int i = 0; i < numberOfEntry ; i++){
	
	var newConfigObject = new ConfigObject { DomainId = getDomainId, ConfigObjectTypeId = getConfigObjectTypeId };
	
	//Save data
	AddObject("ConfigObject", newConfigObject);
	SaveChanges();
	
}