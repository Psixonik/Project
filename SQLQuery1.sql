Create table Details( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					type nvarchar(50) not null,
					col int,
					money decimal );
insert into Details values (N'кузов', N'МАЗ',3,11.11),
						(N'кузов', N'КрАЗ',7,2),
						(N'кузов', N'БТР',10,3.33),
						(N'колесо', N'260',7,0.4),
						(N'колесо', N'320',30,55.55),
						(N'мотор', N'Мотор для МАЗа',0,17.80),
						(N'мотор', N'Мотор для КрАЗа',10,25.90),
						(N'мотор', N'Мотор для ЗИЛа',1,10.00);

Create table Zakazs( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					col int,
					money decimal,
					typeMashiID int);
insert into Zakazs values (N'КрАЗ', 1,100,1),
						(N'МАЗ', 7,70.21,2),
						(N'БТР', 3,0.10,4);


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

drop table Details;
drop table Zakazs;
drop table TypeMashins;

select * from Zakazs;