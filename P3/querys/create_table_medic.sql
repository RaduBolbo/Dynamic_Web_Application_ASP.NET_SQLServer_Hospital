
create table medic(
medicid int not null identity,
numemedic varchar(45) null default null,
prenumemedic varchar(45) null default null,
specializare varchar(45) null default null,
primary key(medicid));

/*
MS SQL nu accepta keyword-ul UNSIGNED
identity =  auto_increment.
bigint - 8 Bytes
varchar - il aleg pentru alocare dinamica, pentru a nu ocupa dspatiu pe diskl aiurea
*/