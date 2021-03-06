SELECT c.Name, sum(p.Price)
FROM Companies c
    JOIN Departments d ON c.Id = d.CompanyId
    JOIN Categories k ON d.Id = k.DepartmentId
    JOIN Products p ON k.Id = p.CategoryId
GROUP BY c.Name
ORDER BY sum(p.Price);