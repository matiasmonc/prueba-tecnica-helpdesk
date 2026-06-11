USE helpdesk
GO

DECLARE @Page INT = 1;
DECLARE @PageSize INT = 5;
DECLARE @Status NVARCHAR(50) = 'Open';
DECLARE @Priority NVARCHAR(50) = 'Medium';

WITH Tickets AS (
SELECT
	t.Id AS IdTicket,
	t.Title,
	t.[Description],
	t.CreatedAt,
	u.DisplayName,
	COUNT(c.IdTicket) AS CommentsCount,
	s.Name AS [Status],
	p.Name AS [Priority],
	COUNT(*) OVER() AS TotalFilteredRows
FROM Ticket t LEFT JOIN Comment c
ON t.Id = c.IdTicket
INNER JOIN [User] u 
ON t.CreatedBy = u.Id
INNER JOIN [Status] s 
ON t.IdStatus = s.Id
INNER JOIN [Priority] p
ON t.IdPriority = p.Id
WHERE p.Name = @Priority AND s.Name = @Status
GROUP BY t.Id,
	t.Title,
	t.[Description],
	t.CreatedAt,
	u.DisplayName,s.Name,
	p.Name
)

SELECT
	IdTicket,
	Title,
	[Description],
	CreatedAt,
	DisplayName,
	CommentsCount,
	[Status],
	[Priority],
	TotalFilteredRows,
	CEILING(CAST(TotalFilteredRows AS FLOAT) / @PageSize) AS TotalPages 
FROM Tickets
ORDER BY CreatedAt DESC
OFFSET (@Page - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;


SELECT TOP 5
	u.Id,
	u.DisplayName,
	COUNT(t.Id) AS CountTickets
FROM [User] u INNER JOIN Ticket t
ON u.Id = t.CreatedBy
WHERE t.CreatedAt >= DATEADD(MONTH, -1, GETDATE()) 
GROUP BY u.Id, u.DisplayName;



DECLARE @Q NVARCHAR(2000) = 'LOREM';

SELECT
	t.Title,
	t.[Description],
	t.CreatedAt,
	u.DisplayName,
	s.Name AS [Status],
	p.Name AS [Priority]
FROM Ticket t
INNER JOIN [User] u 
ON t.CreatedBy = u.Id
INNER JOIN [Status] s 
ON t.IdStatus = s.Id
INNER JOIN [Priority] p
ON t.IdPriority = p.Id
WHERE t.Description LIKE '%'+@Q+'%' OR t.Title LIKE '%'+@Q+'%'




DECLARE @DEADLINE DATETIME = DATEADD(DAY, -2, GETDATE())

SELECT
	t.Title,
	t.[Description],
	t.CreatedAt,
	u.DisplayName,
	s.Name AS [Status],
	p.Name AS [Priority]
FROM Ticket t
INNER JOIN [User] u 
ON t.CreatedBy = u.Id
INNER JOIN [Status] s 
ON t.IdStatus = s.Id
INNER JOIN [Priority] p
ON t.IdPriority = p.Id
WHERE t.CreatedAt < @DEADLINE
AND s.Name NOT IN ('Resolved', 'Closed')
ORDER BY t.CreatedAt DESC
