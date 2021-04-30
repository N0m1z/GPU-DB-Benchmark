SELECT DISTINCT c.Name, c.Email, c.PhoneNumber
FROM Companies c
    JOIN Departments d ON c.Id = d.CompanyId
    JOIN Categories k ON d.Id = k.DepartmentId
WHERE k.Name = 'Electronics';