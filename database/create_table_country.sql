create table country
(
    countryId   int identity
        constraint country_pk
            primary key,
    countryName varchar(250) not null
)
go

exec sp_addextendedproperty 'MS_Description', 'Paises disponibles para crear registros ligados a ubicación', 'SCHEMA',
     'dbo', 'TABLE', 'country'
go

create unique index country_countryId_uindex
    on country (countryId)
go

create unique index country_countryName_uindex
    on country (countryName)
go

