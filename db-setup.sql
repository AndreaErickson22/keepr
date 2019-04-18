USE keepr22;

-- CREATE TABLE users
-- (
--   id VARCHAR(255) NOT NULL,
--   username VARCHAR(20) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   hash VARCHAR(255) NOT NULL,
--   CONSTRAINT PK_users PRIMARY KEY (id),
--   UNIQUE
--   KEY email
--   (email)
-- );
-- INSERT INTO users(id, username, email) VALUES("22", "andrea", "andrea@andrea.com");


-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX idx_userId (userId),
--     constraint FK_vaultsUid FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--    constraint PK_vaults PRIMARY KEY (id)
-- );



-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     keeps INT DEFAULT 0,
--     INDEX idx_userId (userId),
--     CONSTRAINT FK_keepsUid FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--    CONSTRAINT PK_keeps PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps
-- (
--   id int NOT NULL
--   AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR
--   (255) NOT NULL,

--     CONSTRAINT PK_vaultkeeps PRIMARY KEY
--   (id),
--     INDEX idx_vid_kid
--   (vaultId, keepId),
--     INDEX idx_userid
--   (userId),

--    CONSTRAINT FK_vaultkeepsUid FOREIGN KEY
--   (userId)
--         REFERENCES users
--   (id)
--         ON
--   DELETE CASCADE,

--    CONSTRAINT FK_vaultkeepsVid FOREIGN KEY
--   (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

-- CONSTRAINT FK_vaultkeepsKid FOREIGN KEY(keepId)
-- REFERENCES keeps(id) 
-- ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 


-- INSERT INTO keeps(name, description, img) VALUES("Dog Keepr", "this keep is all about the dogs", "https:
-- //cdn2-www.dogtime.com/assets/uploads/gallery/golden-retriever-dogs-and-puppies/golden-retriever-dogs-puppies-9.jpg");


-- DELETE FROM keeps WHERE id = 1;
-- INSERT INTO keeps(name, description, img) VALUES("Elephant Keepr", "this keep is all about the elephants", "https:
-- //d3i6fh83elv35t.cloudfront.net/newshour/app/uploads/2015/05/542106059-1024x683.jpg");


-- INSERT INTO vaults
--   (name, description)
-- VALUES("Elephant Vault", "this vault is all about the elephants");
-- INSERT INTO vaults
--   (name, description)
-- VALUES("Monkey Vault", "this vault is all about the monkeys");

