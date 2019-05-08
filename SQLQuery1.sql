use master
go
create database DATEDB
go
USE DATEDB
Create table USERS (
USERID INT IDENTITY PRIMARY KEY,
USERNAME VARCHAR(30),
PASS VARCHAR(30)
)
Create table USERPROFIL (
UPID INT IDENTITY PRIMARY KEY,
FNAME VARCHAR(40),
AGE INT,
HEIGHT INT,
KILO INT,
SEX INT,
USERID INT,
FOREIGN KEY (USERID) REFERENCES USERS(USERID)
)
CREATE TABLE SEARCHPROFIL (
SPID INT IDENTITY PRIMARY KEY,
MINAGE INT,
MAXAGE INT,
INTERESSER INT,
USERID INT,
FOREIGN KEY (USERID) REFERENCES USERS(USERID)
)
CREATE TABLE MATCHES (
MATCHID INT IDENTITY PRIMARY KEY,
USERID1 INT,
USERID2 int,
LIKED BIT,
FOREIGN KEY(USERID1) REFERENCES USERS(USERID),
FOREIGN KEY(USERID2) REFERENCES USERS(USERID)
)
CREATE TRIGGER Oprettrigger
ON DATEDB.USERS
AFTER INSERT
BEGIN
INSERT INTO USERPROFIL(USERID) VALUES()

END
