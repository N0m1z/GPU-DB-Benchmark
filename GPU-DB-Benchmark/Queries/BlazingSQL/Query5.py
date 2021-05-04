from blazingsql import BlazingContext
bc = BlazingContext()

company_types = ['int64', 'str', 'date', 'str', 'str', 'str']
bc.create_table('companies', '/home/nomis/500MB_CSV/Companies.csv', dtype=company_types)
address_types = ['int64', 'str', 'str', 'str', 'str', 'str', 'str', 'str', 'int64']
bc.create_table('addresses', '/home/nomis/500MB_CSV/Addresses.csv', dtype=address_types)
department_types = ['int64', 'str', 'int64']
bc.create_table('departments', '/home/nomis/500MB_CSV/Departments.csv', dtype=department_types)
category_types = ['int64', 'str', 'int64']
bc.create_table('categories', '/home/nomis/500MB_CSV/Categories.csv', dtype=category_types)
product_types = ['int64', 'str', 'str', 'str', 'str', 'date', 'float64', 'int64']
bc.create_table('products', '/home/nomis/500MB_CSV/Products.csv', dtype=product_types)
review_types = ['int64', 'str', 'str', 'date', 'int64']
bc.create_table('reviews', '/home/nomis/500MB_CSV/Reviews.csv', dtype=review_types)

query = '''
SELECT p.Name, p.Id
FROM Products p, Reviews r
WHERE p.Id = r.ProductId AND p.Price >= 990
GROUP BY p.Name, p.Id
HAVING COUNT(*) >= 9
    '''

af = bc.sql(query)
