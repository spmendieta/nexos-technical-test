create table book
(
    bookId        int identity
        constraint book_pk
            primary key,
    title         varchar(200) not null,
    year          date         not null,
    genreId       int          not null,
    numberOfPages smallint     not null,
    editorialId   int          not null
        constraint fk__book__editorial
            references editorial,
    authorId      int          not null
)
go

exec sp_addextendedproperty 'MS_Description', 'Tabla para el almacenamiento de la información relacionada a los libros',
     'SCHEMA', 'dbo', 'TABLE', 'book'
go

exec sp_addextendedproperty 'MS_Description', 'Genero', 'SCHEMA', 'dbo', 'TABLE', 'book', 'COLUMN', 'genreId'
go

create unique index book_bookId_uindex
    on book (bookId)
go

