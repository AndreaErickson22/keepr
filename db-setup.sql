USE keeper22;

-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     hash VARCHAR(255) NOT NULL,
--     contstraint PK_users PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

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
--     contstraint FK_keepsUid FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--    contstraint PK_keeps PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     costraint PK_vaultkeeps PRIMARY KEY (id),
--     INDEX idx_vid_kid(vaultId, keepId),
--     INDEX idx_userid(userId),

--     constraint FK_vaultkeepsUid FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     contstraint FK_vaultkeepsVid FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     contstraint FK_vaultkeepsKid FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 
