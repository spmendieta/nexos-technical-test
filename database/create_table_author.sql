create table author
(
    authorId             int identity
        constraint author_pk
            primary key,
    authorFirstName      varchar(200) not null,
    authorSecondName     varchar(200),
    authorFirstLastName  varchar(200) not null,
    authorSecondLastName varchar(200),
    bornDate             date         not null,
    originCity           int          not null,
    authorEmail          varchar(200) not null
)
go

exec sp_addextendedproperty 'MS_Description', 'Información de los autores vinculados a los libros dentro del sistema',
     'SCHEMA', 'dbo', 'TABLE', 'author'
go

create unique index author_authorId_uindex
    on author (authorId)
go

create unique index author_authorEmail_uindex
    on author (authorEmail)
go