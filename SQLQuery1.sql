Create table Detail( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					type nvarchar(50) not null,
					col int);
insert into Detail values (N'кузов', N'МАЗ',3),
						(N'кузов', N'КрАЗ',7),
						(N'кузов', N'БТР',10),
						(N'колесо', N'260',7),
						(N'колесо', N'320',30),
						(N'мотор', N'Мотор для МАЗа',0),
						(N'мотор', N'Мотор для КрАЗа',10),
						(N'мотор', N'Мотор для ЗИЛа',1);

Create table Zakazs( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					col int,
					money int,
					typeMashiID int);
insert into Zakazs values (N'КрАЗ', 1,100,1),
						(N'МАЗ', 7,70,2),
						(N'БТР', 3,10,4);


Create table TypeMashins( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					kyzov nvarchar(50) not null,
					colKyzov int,
					koleso nvarchar(50) not null,
					colKoleso int,
					motor nvarchar(50) not null,
					colMotor int);


insert into TypeMashins values (N'КрАЗ',1, N'320',6,N'Мотор для КрАЗа',1),
						(N'МАЗ',1, N'260',4,N'Мотор для МАЗа',1),
						(N'ЗИЛ',1, N'260',4,N'Мотор для ЗИЛа',1),
						(N'БТР',1, N'320',8,N'Мотор для КрАЗа',2);

Create table Moneys( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					cash int,
					credit int,
					dayForCredit int);
insert into Moneys values (100,0,0);

Create table Bazaars (	id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						name nvarchar(50) not null,
						type nvarchar(50) not null,
						money int);
Insert into Bazaars values (N'кузов',N'МАЗ',10),
							(N'кузов',N'КрАЗ',15),
							(N'кузов',N'БТР',23),
							(N'колесо',N'260',5),
							(N'колесо',N'320',7),
							(N'мотор',N'Мотор для МАЗа',17),
							(N'мотор',N'Мотор для КрАЗа',25),
							(N'мотор',N'Мотор для ЗИЛа',10);

Create table NameOfMashins (	id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
								name nvarchar(50) not null);
Insert into NameOfMashins values	(N'МАЗ'),
									(N'КрАЗ'),
									(N'ЗИЛ'),
									(N'БТР');
Create table Workers (id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						colWorkers int,
						zp int);
Insert into Workers values (3,50);

Create table Credits (id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						cash int,
						day int);
insert into Credits values (1000,5),
							(1500,10),
							(2000,15);

drop table Details;
drop table Zakazs;
drop table TypeMashins;
drop table Moneys;
drop table Bazaars;
drop table NameOfMashins;