from blazingsql import BlazingContext
bc = BlazingContext()

company_types = ['int64', 'str', 'date', 'str', 'str', 'str']
bc.create_table('companies', '/home/nomis/20GB_CSV/Companies.csv', dtype=company_types)
address_types = ['int64', 'str', 'str', 'str', 'str', 'str', 'str', 'str', 'int64']
bc.create_table('addresses', '/home/nomis/20GB_CSV/Addresses.csv', dtype=address_types)
department_types = ['int64', 'str', 'int64']
bc.create_table('departments', '/home/nomis/20GB_CSV/Departments.csv', dtype=department_types)
category_types = ['int64', 'str', 'int64']
bc.create_table('categories', '/home/nomis/20GB_CSV/Categories.csv', dtype=category_types)
product_types = ['int64', 'str', 'str', 'str', 'str', 'date', 'float64', 'int64']
bc.create_table('products', '/home/nomis/20GB_CSV/Products.csv', dtype=product_types)
review_types = ['int64', 'str', 'str', 'date', 'int64']
bc.create_table('reviews', '/home/nomis/20GB_CSV/Reviews.csv', dtype=review_types)

query = '''
SELECT a.City
FROM Addresses a
    JOIN Companies c ON a.CompanyId = c.Id
    JOIN Departments d ON c.Id = d.CompanyId
    JOIN Categories k ON d.Id = k.DepartmentId
    JOIN Products p ON k.Id = p.CategoryId
    JOIN Reviews r ON p.Id = r.ProductId
WHERE YEAR(r.PublishDate) >= '2021'
GROUP BY a.City
    '''

af = bc.sql(query)
