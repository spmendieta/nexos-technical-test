create table editorial
(
    editorialId           int identity
        constraint editorial_pk
            primary key,
    editorialName         varchar(250)   not null,
    correspondanceAdress  varchar(250)   not null,
    phone                 varchar(250)   not null,
    email                 varchar(250)   not null,
    bookRegistrationLimit int default -1 not null
)
go

exec sp_addextendedproperty 'MS_Description',
     'Tabla para el almacenamiento de la información relacionada a las editoriales', 'SCHEMA', 'dbo', 'TABLE',
     'editorial'
go

create unique index editorial_editorialId_uindex
    on editorial (editorialId)
go

alter table editorial
    add cityId int default 1 not null
go

alter table editorial
    add constraint fk__editorial__city
        foreign key (cityId) references city
go


