SELECT c.Name, a.Country, c.FoundingDate
FROM Companies c JOIN Addresses a ON c.Id = a.CompanyId
WHERE c.FoundingDate <= '23/05/1949' AND a.Country = 'Germany';