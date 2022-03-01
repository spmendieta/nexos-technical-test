create table city
(
    cityId     int identity
        constraint city_pk
            primary key,
    cityName   varchar(200) not null,
    provinceId int          not null
        constraint fk__city__province
            references province
)
go

exec sp_addextendedproperty 'MS_Description', 'Ciudades disponibles para crear registros ligados a ubicación', 'SCHEMA',
     'dbo', 'TABLE', 'city'
go

create unique index city_cityId_uindex
    on city (cityId)
go

