-- Bang tai khoan cho chuc nang Dang nhap / Dang ky
-- Chay trong MySQL Workbench (database library)
USE `library`;

CREATE TABLE IF NOT EXISTS Account (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,   -- mat khau da bam PBKDF2 (salt:hash), khong luu mat khau goc
    FullName VARCHAR(150) NOT NULL,
    Role VARCHAR(20) NOT NULL DEFAULT 'USER',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tai khoan quan tri mac dinh: admin / admin123
INSERT INTO Account (Username, PasswordHash, FullName, Role)
SELECT 'admin', 'rWSZQ0hu1aYDI1O40bKQjg==:hxEtAZzcpGkM2BWUoK8LkWxtCeFN0usRloQrrdiHrQc=', 'Quản trị viên', 'ADMIN' FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM Account WHERE Username = 'admin');
