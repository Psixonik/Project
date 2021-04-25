drop table Details;
drop table Zakazs;
drop table TypeMashins;
drop table Moneys;
drop table Bazaars;
drop table NameOfMashins;
drop table Credits;
drop table Workers;
drop table Autoes;
drop table Utilits;

Create table Details( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					type nvarchar(50) not null,
					col int);
insert into Details values (N'кузов', N'МАЗ',10),
						(N'кузов', N'КрАЗ',10),
						(N'кузов', N'БТР',10),
						(N'колесо', N'260',10),
						(N'колесо', N'320',10),
						(N'мотор', N'Мотор для МАЗа',10),
						(N'мотор', N'Мотор для КрАЗа',10);

Create table Zakazs( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					col int,
					money int);
insert into Zakazs values (N'КрАЗ', 1,100),
						(N'МАЗ', 1,200),
						(N'БТР', 1,300);


Create table TypeMashins( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					kyzov nvarchar(50) not null,
					colKyzov int,
					koleso nvarchar(50) not null,
					colKoleso int,
					motor nvarchar(50) not null,
					colMotor int);


insert into TypeMashins values (N'КрАЗ',1, N'260',4,N'Мотор для КрАЗа',1),
						(N'МАЗ',1, N'260',4,N'Мотор для МАЗа',1),
						(N'ЗИЛ',1, N'260',4,N'Мотор для ЗИЛа',1),
						(N'БТР',1, N'320',8,N'Мотор для КрАЗа',2);


Create table Bazaars (	id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						name nvarchar(50) not null,
						type nvarchar(50) not null,
						money int);
Insert into Bazaars values (N'кузов',N'МАЗ',10),
							(N'кузов',N'КрАЗ',20),
							(N'кузов',N'БТР',30),
							(N'колесо',N'260',10),
							(N'колесо',N'320',20),
							(N'мотор',N'Мотор для МАЗа',10),
							(N'мотор',N'Мотор для КрАЗа',20),
							(N'мотор',N'Мотор для ЗИЛа',30);


Create table Workers (id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						colWorkers int,
						zp int,
						al int,
						dayOfStrike int);
Insert into Workers values (3,50, 150,0);

Create table Credits (id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						cash int,
						day int);
insert into Credits values (1000,5),
							(1500,10),
							(2000,15);


Create table Utilits(id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
						gas int,
						water int,
						electro int);

Insert into Utilits values (100,100,100);

Create table NameOfMashins (	id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
				nameAuto nvarchar(50) not null,
				cost int,
				services int,
				content int);
Insert into NameOfMashins values	(N'ЗИЛ',1000,100,1000),
				(N'МАЗ',5000,150,1500),
				(N'КрАЗ',25000,300,3000);


Create table Moneys( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					cash int,
					credit int,
					dayForCredit int);
insert into Moneys values (10000,0,0);

Create table Autoes(	id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
				nameAuto nvarchar(50) not null,
				services int,
				maxContent int,
				content int,
				broken int);



