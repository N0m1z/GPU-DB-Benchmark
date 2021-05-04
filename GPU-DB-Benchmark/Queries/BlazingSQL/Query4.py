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
SELECT DISTINCT c.Name, c.Email, c.PhoneNumber
FROM Companies c
    JOIN Departments d ON c.Id = d.CompanyId
    JOIN Categories k ON d.Id = k.DepartmentId
WHERE k.Name = 'Electronics'
    '''

af = bc.sql(query)
