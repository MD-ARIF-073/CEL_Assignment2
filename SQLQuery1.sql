
create database project 

use project

create table student
{
 id int primary key identity,
 sname nvarchar(50),
 sadd nvarchar(50),
 phone int,
 sem int,
 dept nvarchar(50),
 };

 drop table student;

 begin transaction

 insert into student values ('arif','zigatola',01904476050,8,'CSE');
 insert into student values ('jofa','agargoan',01982742925, 7 , 'MECHANICAL');
 insert into student values ('abdullah','katabon',01983957352,6,'MECHANICAL');
 insert into student values ('labib','science lab',01902134891,8,'CSE');

 COMMIT;

 update student set sadd = 'shonkor' where sname = 'labib';


 select * from student;
