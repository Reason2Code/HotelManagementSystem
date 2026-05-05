create database HotelDB
use HotelDB

DROP TABLE IF EXISTS customer;
DROP TABLE IF EXISTS rooms;
DROP TABLE IF EXISTS employee;


CREATE TABLE rooms (
    roomid INT IDENTITY(1,1) PRIMARY KEY, 
    roomNo VARCHAR(50) UNIQUE NOT NULL,   
    roomType VARCHAR(50) NOT NULL,
    bed VARCHAR(50) NOT NULL,
    price BIGINT NOT NULL,                
    booked VARCHAR(10) DEFAULT 'NO'       
);

CREATE TABLE customer (
    cid INT IDENTITY(1,1) PRIMARY KEY,
    cName VARCHAR(100) NOT NULL,
    mobile BIGINT,                        
    nationality VARCHAR(50),
    gender VARCHAR(20),
    dob VARCHAR(50),                      
    idproof VARCHAR(100),
    addres VARCHAR(255),
    checkin VARCHAR(50),
    chekout VARCHAR(10) DEFAULT 'No',     
    roomid INT,                           
    
    CONSTRAINT FK_Customer_Rooms FOREIGN KEY (roomid) 
    REFERENCES rooms(roomid) 
    ON DELETE SET NULL
);

CREATE TABLE employee (
    eid INT IDENTITY(1,1) PRIMARY KEY,
    ename VARCHAR(100) NOT NULL,
    mobile BIGINT,                        
    gender VARCHAR(20),
    emailid VARCHAR(100) UNIQUE,
    username VARCHAR(50) UNIQUE NOT NULL,
    pass VARCHAR(255) NOT NULL            
);

INSERT INTO rooms (roomNo, roomType, bed, price, booked) VALUES     
    ('101', 'AC', 'Single', 1500, 'YES'),      
    ('102', 'AC', 'Double', 2500, 'YES'),     
    ('103', 'Non-AC', 'Single', 1000, 'NO'), 
    ('201', 'Suite', 'Double', 5000, 'YES'),   
    ('202', 'Non-AC', 'Double', 1800, 'NO'),  
    ('104', 'AC', 'Single', 1500, 'NO'),      
    ('105', 'Non-AC', 'Double', 1800, 'NO'),  
    ('203', 'Suite', 'Double', 5000, 'YES'),  
    ('204', 'AC', 'Double', 2500, 'YES'),     
    ('301', 'Suite', 'King', 8000, 'NO');     

INSERT INTO customer (cName, mobile, nationality, gender, dob, idproof, addres, checkin, roomid) VALUES     
    ('John Doe', 9876543210, 'American', 'Male', '15/05/1990', 'Passport-A123', '123 Maple St, NY', '26/10/2023', 1),    
    ('Jane Smith', 8765432109, 'British', 'Female', '22/08/1985', 'License-B456', '456 Oak Ave, London', '27/10/2023', 2),    
    ('Ali Khan', 7654321098, 'Emirati', 'Male', '10/11/1992', 'ID-C789', '789 Pine Rd, Dubai', '27/10/2023', 4);

INSERT INTO customer (cName, mobile, nationality, gender, dob, idproof, addres, checkin, roomid, chekout) VALUES 
    ('Maria Garcia', 6543210987, 'Spanish', 'Female', '05/12/1988', 'ID-D101', 'Gran Via, Madrid', '28/10/2023', 8, 'No'),    
    ('Chen Wei', 5432109876, 'Chinese', 'Male', '18/03/1995', 'Passport-E202', 'Beijing, China', '29/10/2023', 9, 'No'),
    ('Emily Johnson', 4321098765, 'Canadian', 'Female', '30/07/1991', 'License-F303', 'Toronto, ON', '15/10/2023', 3, 'YES');

INSERT INTO employee (ename, mobile, gender, emailid, username, pass) VALUES     
    ('System Admin', 9999999999, 'Other', 'admin@hotel.com', 'admin', 'admin'),    
    ('Sarah Manager', 1234567890, 'Female', 'sarah@hotel.com', 'smanager', 'staffpass123'),    
    ('James Reception', 1000000007, 'Male', 'james@hotel.com', 'jreception', 'deskpass456'),
    ('Michael Guard', 2345678901, 'Male', 'michael@hotel.com', 'mguard', 'security789'),    
    ('Lisa Cleaner', 3456789012, 'Female', 'lisa@hotel.com', 'lcleaner', 'housekeep101'),    
    ('David Audit', 4567890123, 'Male', 'david@hotel.com', 'daudit', 'finance555');

INSERT INTO rooms (roomNo, roomType, bed, price, booked) VALUES 
('302','AC','Single',1500,'NO'),('303','Non-AC','Double',1800,'NO'),('304','Suite','King',8000,'NO'),
('305','AC','Double',2500,'NO'),('306','Non-AC','Single',1000,'NO'),('307','AC','Single',1500,'NO'),
('308','Suite','Double',5000,'NO'),('309','AC','Double',2500,'NO'),('310','Non-AC','Double',1800,'NO'),
('311','AC','Single',1500,'NO'),('312','Non-AC','Single',1000,'NO'),('313','Suite','King',8000,'NO'),
('314','AC','Double',2500,'NO'),('315','Non-AC','Double',1800,'NO'),('316','AC','Single',1500,'NO'),
('317','Suite','Double',5000,'NO'),('318','AC','Double',2500,'NO'),('319','Non-AC','Single',1000,'NO'),
('320','AC','Single',1500,'NO'),('321','Non-AC','Double',1800,'NO'),('322','Suite','King',8000,'NO'),
('323','AC','Double',2500,'NO'),('324','Non-AC','Single',1000,'NO'),('325','AC','Single',1500,'NO'),
('326','Suite','Double',5000,'NO'),('327','AC','Double',2500,'NO'),('328','Non-AC','Double',1800,'NO'),
('329','AC','Single',1500,'NO'),('330','Non-AC','Single',1000,'NO'),('331','Suite','King',8000,'NO'),
('332','AC','Double',2500,'NO'),('333','Non-AC','Double',1800,'NO'),('334','AC','Single',1500,'NO'),
('335','Suite','Double',5000,'NO'),('336','AC','Double',2500,'NO'),('337','Non-AC','Single',1000,'NO'),
('338','AC','Single',1500,'NO'),('339','Non-AC','Double',1800,'NO'),('340','Suite','King',8000,'NO'),
('341','AC','Double',2500,'NO'),('342','Non-AC','Single',1000,'NO'),('343','AC','Single',1500,'NO'),
('344','Suite','Double',5000,'NO'),('345','AC','Double',2500,'NO'),('346','Non-AC','Double',1800,'NO'),
('347','AC','Single',1500,'NO'),('348','Non-AC','Single',1000,'NO'),('349','Suite','King',8000,'NO'),
('350','AC','Double',2500,'NO'),('351','Non-AC','Double',1800,'NO');

INSERT INTO customer (cName, mobile, nationality, gender, dob, idproof, addres, checkin, roomid, chekout) VALUES 
('Liam Wilson',9000000001,'Australian','Male','12/01/1985','ID-1001','Sydney','01/11/2023',11,'No'),
('Noah Brown',9000000002,'Canadian','Male','25/02/1990','ID-1002','Toronto','01/11/2023',12,'No'),
('Oliver Taylor',9000000003,'British','Male','14/03/1992','ID-1003','London','02/11/2023',13,'No'),
('Emma Davies',9000000004,'British','Female','30/04/1988','ID-1004','Manchester','02/11/2023',14,'No'),
('Ava Evans',9000000005,'Welsh','Female','11/05/1993','ID-1005','Cardiff','03/11/2023',15,'No'),
('Sophia Thomas',9000000006,'Scottish','Female','22/06/1987','ID-1006','Glasgow','03/11/2023',16,'No'),
('Isabella Roberts',9000000007,'Irish','Female','05/07/1995','ID-1007','Dublin','04/11/2023',17,'No'),
('Mia Walker',9000000008,'Irish','Female','19/08/1989','ID-1008','Belfast','04/11/2023',18,'No'),
('Charlotte Hall',9000000009,'German','Female','08/09/1991','ID-1009','Berlin','05/11/2023',19,'No'),
('Amelia Young',9000000010,'German','Female','17/10/1984','ID-1010','Munich','05/11/2023',20,'No'),
('Harper King',9000000011,'French','Female','29/11/1996','ID-1011','Paris','06/11/2023',21,'No'),
('Evelyn Wright',9000000012,'French','Female','13/12/1983','ID-1012','Lyon','06/11/2023',22,'No'),
('Abigail Scott',9000000013,'Italian','Female','02/01/1994','ID-1013','Rome','07/11/2023',23,'No'),
('Emily Green',9000000014,'Italian','Female','15/02/1986','ID-1014','Milan','07/11/2023',24,'No'),
('Elizabeth Baker',9000000015,'Spanish','Female','28/03/1992','ID-1015','Madrid','08/11/2023',25,'No'),
('Mila Adams',9000000016,'Spanish','Female','11/04/1989','ID-1016','Barcelona','08/11/2023',26,'No'),
('Ella Nelson',9000000017,'Portuguese','Female','23/05/1990','ID-1017','Lisbon','09/11/2023',27,'No'),
('Avery Hill',9000000018,'Dutch','Female','04/06/1993','ID-1018','Amsterdam','09/11/2023',28,'No'),
('Sofia Ramirez',9000000019,'Mexican','Female','16/07/1987','ID-1019','Mexico City','10/11/2023',29,'No'),
('Camila Flores',9000000020,'Mexican','Female','29/08/1995','ID-1020','Cancun','10/11/2023',30,'No'),
('Aria Benitez',9000000021,'Argentinian','Female','12/09/1988','ID-1021','Buenos Aires','11/11/2023',31,'No'),
('Scarlett Gomez',9000000022,'Brazilian','Female','25/10/1991','ID-1022','Rio','11/11/2023',32,'No'),
('Victoria Silva',9000000023,'Brazilian','Female','06/11/1984','ID-1023','Sao Paulo','12/11/2023',33,'No'),
('Madison Santos',9000000024,'Chilean','Female','19/12/1996','ID-1024','Santiago','12/11/2023',34,'No'),
('Luna Reyes',9000000025,'Peruvian','Female','31/01/1983','ID-1025','Lima','13/11/2023',35,'No'),
('Grace Ortiz',9000000026,'Colombian','Female','13/02/1994','ID-1026','Bogota','13/11/2023',36,'No'),
('Chloe Ramos',9000000027,'Japanese','Female','26/03/1986','ID-1027','Tokyo','14/11/2023',37,'No'),
('Penelope Sato',9000000028,'Japanese','Female','08/04/1992','ID-1028','Osaka','14/11/2023',38,'No'),
('Layla Tanaka',9000000029,'Korean','Female','21/05/1989','ID-1029','Seoul','15/11/2023',39,'No'),
('Riley Park',9000000030,'Korean','Female','03/06/1990','ID-1030','Busan','15/11/2023',40,'No'),
('Zoey Kim',9000000031,'Indian','Female','15/07/1993','ID-1031','Mumbai','16/11/2023',41,'No'),
('Nora Singh',9000000032,'Indian','Female','28/08/1987','ID-1032','Delhi','16/11/2023',42,'No'),
('Lily Sharma',9000000033,'Indian','Female','09/09/1995','ID-1033','Bangalore','17/11/2023',43,'No'),
('Eleanor Gupta',9000000034,'Indian','Female','22/10/1988','ID-1034','Pune','17/11/2023',44,'No'),
('Hannah Verma',9000000035,'Indian','Female','04/11/1991','ID-1035','Chennai','18/11/2023',45,'No'),
('Lillian Das',9000000036,'Indian','Female','17/12/1984','ID-1036','Kolkata','18/11/2023',46,'No'),
('Addison Nair',9000000037,'Indian','Female','29/01/1996','ID-1037','Kochi','19/11/2023',47,'No'),
('Aubrey Rao',9000000038,'Indian','Female','11/02/1983','ID-1038','Hyderabad','19/11/2023',48,'No'),
('Stella Reddy',9000000039,'Indian','Female','24/03/1994','ID-1039','Vizag','20/11/2023',49,'No'),
('Natalie Joshi',9000000040,'Indian','Female','06/04/1986','ID-1040','Ahmedabad','20/11/2023',50,'No'),
('Zoe Iyer',9000000041,'Indian','Female','19/05/1992','ID-1041','Lucknow','21/11/2023',51,'No'),
('Leah Bose',9000000042,'Indian','Female','01/06/1989','ID-1042','Indore','21/11/2023',52,'No'),
('Hazel Kapoor',9000000043,'Indian','Female','14/07/1990','ID-1043','Bhopal','22/11/2023',53,'No'),
('Violet Khan',9000000044,'Indian','Female','27/08/1993','ID-1044','Jaipur','22/11/2023',54,'No'),
('Aurora Malhotra',9000000045,'Indian','Female','08/09/1987','ID-1045','Surat','23/11/2023',55,'No'),
('Savannah Chopra',9000000046,'Indian','Female','21/10/1995','ID-1046','Nashik','23/11/2023',56,'No'),
('Audrey Khanna',9000000047,'Indian','Female','03/11/1988','ID-1047','Nagpur','24/11/2023',57,'No'),
('Brooklyn Kumar',9000000048,'Indian','Female','16/12/1991','ID-1048','Patna','24/11/2023',58,'No'),
('Bella Mishra',9000000049,'Indian','Female','28/01/1984','ID-1049','Ranchi','25/11/2023',59,'No'),
('Claire Pandey',9000000050,'Indian','Female','10/02/1996','ID-1050','Guwahati','25/11/2023',60,'No');

INSERT INTO employee (ename, mobile, gender, emailid, username, pass) VALUES 
('Staff 1', 8000000001, 'Male', 'staff1@hotel.com', 'user1', 'pass1'),
('Staff 2', 8000000002, 'Female', 'staff2@hotel.com', 'user2', 'pass2'),
('Staff 3', 8000000003, 'Male', 'staff3@hotel.com', 'user3', 'pass3'),
('Staff 4', 8000000004, 'Female', 'staff4@hotel.com', 'user4', 'pass4'),
('Staff 5', 8000000005, 'Male', 'staff5@hotel.com', 'user5', 'pass5'),
('Staff 6', 8000000006, 'Female', 'staff6@hotel.com', 'user6', 'pass6'),
('Staff 7', 8000000007, 'Male', 'staff7@hotel.com', 'user7', 'pass7'),
('Staff 8', 8000000008, 'Female', 'staff8@hotel.com', 'user8', 'pass8'),
('Staff 9', 8000000009, 'Male', 'staff9@hotel.com', 'user9', 'pass9'),
('Staff 10', 8000000010, 'Female', 'staff10@hotel.com', 'user10', 'pass10'),
('Staff 11', 8000000011, 'Male', 'staff11@hotel.com', 'user11', 'pass11'),
('Staff 12', 8000000012, 'Female', 'staff12@hotel.com', 'user12', 'pass12'),
('Staff 13', 8000000013, 'Male', 'staff13@hotel.com', 'user13', 'pass13'),
('Staff 14', 8000000014, 'Female', 'staff14@hotel.com', 'user14', 'pass14'),
('Staff 15', 8000000015, 'Male', 'staff15@hotel.com', 'user15', 'pass15'),
('Staff 16', 8000000016, 'Female', 'staff16@hotel.com', 'user16', 'pass16'),
('Staff 17', 8000000017, 'Male', 'staff17@hotel.com', 'user17', 'pass17'),
('Staff 18', 8000000018, 'Female', 'staff18@hotel.com', 'user18', 'pass18'),
('Staff 19', 8000000019, 'Male', 'staff19@hotel.com', 'user19', 'pass19'),
('Staff 20', 8000000020, 'Female', 'staff20@hotel.com', 'user20', 'pass20'),
('Staff 21', 8000000021, 'Male', 'staff21@hotel.com', 'user21', 'pass21'),
('Staff 22', 8000000022, 'Female', 'staff22@hotel.com', 'user22', 'pass22'),
('Staff 23', 8000000023, 'Male', 'staff23@hotel.com', 'user23', 'pass23'),
('Staff 24', 8000000024, 'Female', 'staff24@hotel.com', 'user24', 'pass24'),
('Staff 25', 8000000025, 'Male', 'staff25@hotel.com', 'user25', 'pass25'),
('Staff 26', 8000000026, 'Female', 'staff26@hotel.com', 'user26', 'pass26'),
('Staff 27', 8000000027, 'Male', 'staff27@hotel.com', 'user27', 'pass27'),
('Staff 28', 8000000028, 'Female', 'staff28@hotel.com', 'user28', 'pass28'),
('Staff 29', 8000000029, 'Male', 'staff29@hotel.com', 'user29', 'pass29'),
('Staff 30', 8000000030, 'Female', 'staff30@hotel.com', 'user30', 'pass30'),
('Staff 31', 8000000031, 'Male', 'staff31@hotel.com', 'user31', 'pass31'),
('Staff 32', 8000000032, 'Female', 'staff32@hotel.com', 'user32', 'pass32'),
('Staff 33', 8000000033, 'Male', 'staff33@hotel.com', 'user33', 'pass33'),
('Staff 34', 8000000034, 'Female', 'staff34@hotel.com', 'user34', 'pass34'),
('Staff 35', 8000000035, 'Male', 'staff35@hotel.com', 'user35', 'pass35'),
('Staff 36', 8000000036, 'Female', 'staff36@hotel.com', 'user36', 'pass36'),
('Staff 37', 8000000037, 'Male', 'staff37@hotel.com', 'user37', 'pass37'),
('Staff 38', 8000000038, 'Female', 'staff38@hotel.com', 'user38', 'pass38'),
('Staff 39', 8000000039, 'Male', 'staff39@hotel.com', 'user39', 'pass39'),
('Staff 40', 8000000040, 'Female', 'staff40@hotel.com', 'user40', 'pass40'),
('Staff 41', 8000000041, 'Male', 'staff41@hotel.com', 'user41', 'pass41'),
('Staff 42', 8000000042, 'Female', 'staff42@hotel.com', 'user42', 'pass42'),
('Staff 43', 8000000043, 'Male', 'staff43@hotel.com', 'user43', 'pass43'),
('Staff 44', 8000000044, 'Female', 'staff44@hotel.com', 'user44', 'pass44'),
('Staff 45', 8000000045, 'Male', 'staff45@hotel.com', 'user45', 'pass45'),
('Staff 46', 8000000046, 'Female', 'staff46@hotel.com', 'user46', 'pass46'),
('Staff 47', 8000000047, 'Male', 'staff47@hotel.com', 'user47', 'pass47'),
('Staff 48', 8000000048, 'Female', 'staff48@hotel.com', 'user48', 'pass48'),
('Staff 49', 8000000049, 'Male', 'staff49@hotel.com', 'user49', 'pass49'),
('Staff 50', 8000000050, 'Female', 'staff50@hotel.com', 'user50', 'pass50');