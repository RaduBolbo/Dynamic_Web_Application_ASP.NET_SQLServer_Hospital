
create table consultatie(
consultatieid int not null identity,
medicid int null default null, /*FK1*/
pacientid int null default null, /*FK2*/
medicamentid int null default null, /*FK3*/
data date null default null,
diagnostic varchar(45) null default null,
dozamedicament varchar(45) null default null,
primary key(consultatieid));

ALTER TABLE consultatie
   ADD CONSTRAINT fk_consultatie_1 FOREIGN KEY (medicid)
      REFERENCES medic (medicid)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE consultatie
   ADD CONSTRAINT fk_consultatie_2 FOREIGN KEY (pacientid)
      REFERENCES pacient (pacientid)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE consultatie
   ADD CONSTRAINT fk_consultatie_3 FOREIGN KEY (medicamentid)
      REFERENCES medicamente (medicamentid)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

/*
- se adauga si constrageriule de fk
- se va considera CASAXCDE, la deletesi la update, deci modificarile si stergerile se vor porpaga in tabele
*/
