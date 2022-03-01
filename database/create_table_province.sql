create table province
(
    provinceId   int identity
        constraint province_pk
            primary key,
    provinceName varchar(250) not null,
    countryId    int          not null
        constraint fk___province__country
            references country
)
go

exec sp_addextendedproperty 'MS_Description',
     'Provincias o departamentos geográficos disponibles para crear registros ligados a ubicación', 'SCHEMA', 'dbo',
     'TABLE', 'province'
go

create unique index province_provinceId_uindex
    on province (provinceId)
go

