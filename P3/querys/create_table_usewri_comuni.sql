create table useri_comuni(
useri_comuniid int not null identity,
username nvarchar(45) not null,
password nvarchar(250) not null
primary key(useri_comuniid));