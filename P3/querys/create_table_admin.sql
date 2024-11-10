

create table useri_admin(
useri_adminid int not null identity,
username nvarchar(45) not null,
password nvarchar(250) not null
primary key(useri_adminid));
