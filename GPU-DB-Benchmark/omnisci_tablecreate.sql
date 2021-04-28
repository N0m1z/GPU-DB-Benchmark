CREATE TABLE IF NOT EXISTS addresses (
id BIGINT NOT NULL,
zipcode TEXT,
city TEXT,
streetname TEXT,
buildingnumber TEXT,
secondaryaddress TEXT,
countrycode TEXT,
country TEXT,
companyid BIGINT);

CREATE TABLE IF NOT EXISTS categories (
id BIGINT NOT NULL,
name TEXT,
departmentid BIGINT);

CREATE TABLE IF NOT EXISTS companies (
id BIGINT NOT NULL,
name TEXT,
foundingdate TEXT,
email TEXT,
website TEXT,
phonenumber TEXT);

CREATE TABLE IF NOT EXISTS departments (
id BIGINT NOT NULL,
name TEXT,
companyid BIGINT);

CREATE TABLE IF	NOT EXISTS products (
id BIGINT NOT NULL,
name TEXT,
color TEXT,
material TEXT,
ean13 TEXT,
releasedate TEXT,
price DOUBLE,
categoryid BIGINT);

CREATE TABLE IF NOT EXISTS reviews (
id BIGINT NOT NULL,
author TEXT,
reviewtext TEXT,
publishdate TEXT,
productid BIGINT);
