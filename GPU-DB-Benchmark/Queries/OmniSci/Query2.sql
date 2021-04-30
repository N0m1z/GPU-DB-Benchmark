SELECT c.Name, a.Country, c.FoundingDate
FROM Companies c JOIN Addresses a ON c.Id = a.CompanyId
WHERE c.FoundingDate <= '01/01/2021' AND a.Country = 'Guam';