SELECT c.name
FROM categories c JOIN products p ON c.id = p.categoryid
WHERE c.id < 3;
