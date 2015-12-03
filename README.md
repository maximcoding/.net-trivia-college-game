# TRIVIA
Mobile and Desktop Application - Quizz Game 
C#,ADO.NET,Win Forms,jQuery Mobile,Bootstrap,CSS3 Animations,MS Server Database 
------------------------
________________________
--------------
CLIENT SIDE CODE  ( Contains Mobile and Desktop Versions UI) 
________________________________
Placed in directory  : Trivia-Master - UILayer 
________________________________
--------------
Used in code :
_________________
IAsyncHttpHandler,Session,Cookies,MultiView,Validators,BundleConfig,Master Pages.
Json Helper Class named as JsonHelper.cs for retrieving list ob objects in JSON format
________________________________


SERVER SIDE CODE (Contains Models And Data Access Objects to each Model)  
_______________________________
Placed in directory  : Trivia-Master - DALayer
________________________________
--------------
Used in code :
_________________
Stored Procedures ,Models,Dataset,Datatables,SqlConnection.
______________________________
DTableExtension.cs > generic helper class using for creating dynamically instance of models with it individual properties .

One of Stored Procedure :
______________________________
SELECT * FROM(
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
WHERE Fafa.PlayerId = @PlayerId
_____________________________
The result is : 
____________________________
Picture resized and renamed :                   Email:          Username:  Registration Date:     Place:  PlayerID: TotalScore: AverageScode :   TotalGames:
_______________________________________________________________________________________________________________________________
27bfe528-df0b-42dc-9110-28137a92de0ejinge.jpg	  jinji@mail.com	jinji	   2015-11-27 16:38:37.957	  1	       1	       27	   27	  1







