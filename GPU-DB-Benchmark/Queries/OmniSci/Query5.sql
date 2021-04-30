SELECT p.Name, p.Id
FROM Products p, Reviews r
WHERE p.Id = r.ProductId
GROUP BY p.Name, p.Id
HAVING COUNT(*) >= 9;