create table RegUser (
regUser_id int identity(1,1) not null,
regUser_name varchar(50) not null,
email varchar(50) not null,
regUser_key binary(20) not null,
salt binary(20) not null,
height int not null,
weight int not null,
age int not null,
sex bit not null,
location varchar(50) not null,
primary key (regUser_id))

create table Sport (
sport_id int identity(1,1) not null,
sport_name varchar(50) not null,
olympic_type varchar(50) not null,
individual bit not null,
min_age int not null,
max_age int not null,
primary key (sport_id))

create table Achievement(
achievement_id int Identity(1,1) not null,
regUser_id int not null foreign key references RegUser (regUser_id),
sport_id int not null foreign key references Sport (sport_id),
achievement_name varchar(100) not null,
achievement_type varchar(50) not null,
category int,
competition_result int,
achievement_date int not null,
primary key (achievement_id)
)

create table SportSection(
section_id int identity(1,1) not null,
sport_id int not null foreign key references Sport (sport_id),
section_name varchar(50) not null,
description varchar(2000),
lessons_per_week int not null,
cost int not null, 
section_location varchar(50) not null,
contacts varchar(50) not null,
primary key (section_id)
)

create table Rating (
rating_id int identity(1,1) not null,
regUser_id int not null foreign key references RegUser (regUser_id),
section_id int not null foreign key references SportSection (section_id),
explicit_ bit not null,
rating_weight int not null,
rating_type varchar(50) not null,
rating_date date not null,
request_text varchar(1000),
primary key (rating_id)
)