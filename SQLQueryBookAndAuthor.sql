use admindb


CREATE TABLE Authors(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(100),
Mobile VARCHAR(100),
Email VARCHAR(100)
)

SELECT * FROM Authors;
SELECT * FROM Books;
CREATE TABLE Books(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(100),
Price Money,
Quantity INT,
Published_On VARCHAR(100),
Author_Id INT FOREIGN KEY REFERENCES Authors(Id)
)

INSERT INTO Authors(Name,Mobile,Email)
VALUES('Ajit',8594043329,'anam@gmail.com'),
('tbtan',8845660567,'ckjfd@gmail.com'),
('Mnu',9455433455,'mmfgu@gmail.com')
INSERT INTO Books (Title,Price,Quantity,Published_On,Author_Id)
VALUES('XYZ',55,2,GETDATE(),1),
('Aman',525,1,GETDATE(),2),
('ankit ainfg',25,3,GETDATE(),2),
('naman',5,5,GETDATE(),3),
('aksh',55,4,GETDATE(),3),
('wwwk',52,10,GETDATE(),1)
