### TRIVIA Quizz Game ###
___________________________

Mobile and Desktop Application
___________________________
#### Technologies: ####

- [x] C#, 
- [x] ADO.NET, 
- [x] Win Forms, 
- [x] jQuery Mobile, 
- [x] Bootstrap, 
- [x] CSS3 Animations, 
- [x] MS Server Database 
________________________

``` /Trivia-Master ```  - UILayer

CLIENT SIDE CODE  ( Contains Mobile and Desktop Versions UI) 

IAsyncHttpHandler, Session, Cookies, MultiView, Validators, BundleConfig, Master Pages.
Json Helper Class named as JsonHelper.cs for retrieving list ob objects in JSON format


SERVER SIDE CODE (Contains Models And Data Access Objects to each Model)  
_______________________________
``` /Trivia-Master ```  - DALayer

[x] Stored Procedures ,
[x] Models,
[x] Dataset,
[x] Datatables,
[x] SqlConnection.
______________________________
```DTableExtension.cs``` - generic helper class using for creating dynamically instance of models with it individual properties .


Example One of Stored Procedure :
______________________________
```SELECT * FROM(
SELECT 
Player.image AS Picture,
Player.email AS Email,
Player.username AS Username,
Player.registration_date AS Registration_Date,
row_number() OVER(ORDER BY avg(Game.score) DESC) AS Place,
Game.player_id AS PlayerId,
sum(Game.score) AS TotalScore,
avg(Game.score) AS AverageScore,
count(Game.id) AS TotalGames
FROM Game
INNER JOIN Player
ON Game.player_id=Player.id
GROUP BY Game.player_id,
Player.username,Player.email,Player.image,Player.registration_date)
As Fafa
WHERE Fafa.PlayerId = @PlayerId ```


The result is : 
____________________________
Picture resized and renamed :                   Email:          Username:  Registration Date:     Place:  PlayerID: TotalScore: AverageScode :   TotalGames:
_______________________________________________________________________________________________________________________________
27bfe528-df0b-42dc-9110-28137a92de0ejinge.jpg	  jinji@mail.com	jinji	   2015-11-27 16:38:37.957	  1	       1	       27	   27	  1







