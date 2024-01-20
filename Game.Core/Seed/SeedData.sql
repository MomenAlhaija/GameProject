IF NOT EXISTS (SELECT 1 FROM Categories)
BEGIN
    -- Seed data for Categories
    INSERT INTO Categories (Id, Name) VALUES (1, 'Sports');
    INSERT INTO Categories (Id, Name) VALUES (2, 'Action');
    INSERT INTO Categories (Id, Name) VALUES (3, 'Adventure');
    INSERT INTO Categories (Id, Name) VALUES (4, 'Racing');
    INSERT INTO Categories (Id, Name) VALUES (5, 'Fighting');
    INSERT INTO Categories (Id, Name) VALUES (6, 'Film');
END;
