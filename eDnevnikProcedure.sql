
create procedure [dbo].[God_Odelj]
@Opis nvarchar(50)
as
begin
select 
 g.[Opis],  o.[MatBrOdeljenja]
from
[dbo].[Godine] as g 
inner join [dbo].[Odeljenja] as o 
on g.[GodinaID]=o.GodinaID where 
g.[Opis]  LIKE '%' + @Opis + '%'
end;
go

exec [dbo].[God_Odelj];

go

create procedure SP_Odelj_ListaUcen
@MatBrOdeljenja nvarchar (8)
as
begin
select
o.[MatBrOdeljenja],u.[Ime],u.[Prezime]
from
[dbo].[Odeljenja]  as o
inner join [dbo].[Ucenici] as u
on o.[OdeljenjeID]=u.[OdeljenjeID] where
o.MatBrOdeljenja like '%' + @MatBrOdeljenja + '%'
end;
go

exec SP_Odelj_ListaUcen "1/2/2017";
