SELECT a.City
FROM Addresses a
    JOIN Companies c ON a.CompanyId = c.Id
    JOIN Departments d ON c.Id = d.CompanyId
    JOIN Categories k ON d.Id = k.DepartmentId
    JOIN Products p ON k.Id = p.CategoryId
    JOIN Reviews r ON p.Id = r.ProductId
WHERE r.PublishDate >= '01/01/2021'
GROUP BY a.City;