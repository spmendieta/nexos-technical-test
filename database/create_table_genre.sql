-- auto-generated definition
create table genre
(
    genreId   int identity
        constraint genre_pk
            primary key,
    genreName varchar(250) not null
)
go

exec sp_addextendedproperty 'MS_Description',
     'Tabla para el almacenamiento de la información relacionada a los generos que puede tener un libro', 'SCHEMA',
     'dbo', 'TABLE', 'genre'
go

create unique index genre_genreId_uindex
    on genre (genreId)
go

create unique index genre_genreName_uindex
    on genre (genreName)
go

alter table book
    add constraint fk__book__genre
        foreign key (genreId) references genre
go



