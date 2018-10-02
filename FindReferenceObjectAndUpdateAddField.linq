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

//var categoryName = "AddField";
//var referenceEntityName = "Activity";
/*
var getReferenceObjects = 
					from Obj in ReferenceObject.AsEnumerable() 
                    	join ObjCategory in ReferenceObjectCategory.AsEnumerable() 
                    	on Obj.ReferenceObjectCategoryId equals ObjCategory.Id
                    	where ObjCategory.EntityName.Contains(categoryName)
					where Obj.EntityName.Contains(referenceEntityName)
                    select Obj;
foreach (var list in getReferenceObjects)
{
	System.Console.WriteLine(list);
}
*/
// NEXT

var categoryName = "AddField";
var selectDataSet = from aList in AddField
					where aList.ReferenceObjectId == null && aList.Type == aList.EntityName 
					select aList;
var count = 1;					
foreach (var dataList in selectDataSet){	
	
	System.Console.WriteLine(dataList.Type + " - " + dataList.EntityName + " **");
	
	var referenceEntityName = dataList.Type;

	var getReferenceObjects = 
						from Obj in ReferenceObject.AsEnumerable() 
	                    	join ObjCategory in ReferenceObjectCategory.AsEnumerable() 
	                    	on Obj.ReferenceObjectCategoryId equals ObjCategory.Id
	                    	where ObjCategory.EntityName == categoryName
						where Obj.EntityName == referenceEntityName
	                    select Obj;
						
	foreach (var list in getReferenceObjects)
	{
		System.Console.WriteLine(list.Id + " - " + list.ReferenceObjectName + " - " + list.EntityName + " => " + list.ReferenceObjectCategoryId);
		System.Console.WriteLine("------------------------------------------------");
		//UPDATING
		dataList.ReferenceObjectId = list.Id;
		UpdateObject(dataList);
		SaveChanges();
		
	}
	System.Console.WriteLine("///////////////////////////////////////////////// " + count);
	count++;
	
}

