CREATE TABLE "Addresses" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Addresses" PRIMARY KEY AUTOINCREMENT,
    "ZipCode" TEXT NULL,
    "City" TEXT NULL,
    "StreetName" TEXT NULL,
    "BuildingNumber" TEXT NULL,
    "SecondaryAddress" TEXT NULL,
    "CountryCode" TEXT NULL,
    "Country" TEXT NULL,
    "CompanyId" INTEGER NOT NULL
);

CREATE TABLE "Categories" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "DepartmentId" INTEGER NOT NULL
);

CREATE TABLE "Companies" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Companies" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "FoundingDate" TEXT NOT NULL,
    "Email" TEXT NULL,
    "Website" TEXT NULL,
    "PhoneNumber" TEXT NULL
);

CREATE TABLE "Departments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Departments" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "CompanyId" INTEGER NOT NULL
);

CREATE TABLE "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Color" TEXT NULL,
    "Material" TEXT NULL,
    "Ean13" TEXT NULL,
    "ReleaseDate" TEXT NOT NULL,
    "Price" TEXT NULL,
    "CategoryId" INTEGER NOT NULL
);

CREATE TABLE "Reviews" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Reviews" PRIMARY KEY AUTOINCREMENT,
    "Author" TEXT NULL,
    "ReviewText" TEXT NULL,
    "PublishDate" TEXT NOT NULL,
    "ProductId" INTEGER NOT NULL
);

COMMIT;

