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

var questionnaireName = "Bewertung Seminar";

var list = from q in Question.AsEnumerable()
			join qqs in QuestionnaireQuestionnaireSection.AsEnumerable()
			on q.QuestionnaireQuestionnaireSectionId equals qqs.Id
				join qs in QuestionnaireSection.AsEnumerable()
				on qqs.QuestionnaireSectionId equals qs.Id
					join qq in Questionnaire.AsEnumerable()
					on qqs.QuestionnaireId equals qq.Id
		   where qq.QuestionnaireName == questionnaireName
		   select new { QuestionaireId = qs.Id, QuestionaireName = qs.QuestionnaireFormSectionName, QuestionId = q.Id, QuestionName = q.QuestionName};
		   
list.GroupBy(item => item.QuestionaireName ).Dump("Questionnaire : "+ questionnaireName);