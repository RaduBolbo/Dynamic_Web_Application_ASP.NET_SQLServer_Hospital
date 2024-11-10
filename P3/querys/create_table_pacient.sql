
create table pacient(
pacientid int not null identity,
CNP char(13) unique,
numepacient varchar(45) null default null,
prenumepacient varchar(45) null default null,
adresa varchar(45) null default null,
asigurare varchar(45) null default null,
primary key(pacientid));
/*
voi pune keyword UNIQUE la atributul CNP pentru a forta utilizatorul sa introduca coreect CNP-ul
de asemenea, este char si nu varchar, deoarece nu poate avea decat 13 caractere
*/
