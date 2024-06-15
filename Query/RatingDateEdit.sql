update Rating
set rating_date = Dateadd(day,5, rating_date)

SELECT TOP (1000) [rating_id]
      ,[regUser_id]
      ,[section_id]
      ,[rating_date]
  FROM [SportsRecommendation].[dbo].[Rating]