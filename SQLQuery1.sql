Create table detail( id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
					name nvarchar(50) not null,
					type nvarchar(50) not null,
					col int);

insert into detail values ('kyzov', 'MAZ',3),
						('kyzov', 'KRaZ',7),
						('koleso','260',10),
						('koleso','320',5);

drop table detai;

select * from detail;
