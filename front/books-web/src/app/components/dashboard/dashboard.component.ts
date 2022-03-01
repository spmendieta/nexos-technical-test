import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthorService } from 'src/app/service/author.service';
import { Book } from 'src/app/api/book';
import { BookService } from 'src/app/service/book.service';
import { Author } from 'src/app/api/author';
import { Editorial } from 'src/app/api/editorial';
import { Genre } from 'src/app/api/genre';
import { EditorialService } from 'src/app/service/editorial.service';
import { GenreService } from 'src/app/service/genre.service';

@Component({
    templateUrl: './dashboard.component.html',
    providers: [],
})
export class DashboardComponent implements OnInit {
    subscription: Subscription;

    bookDialog: boolean;

    book: Book;

    submitted: boolean;

    books: Book[];

    genres: Genre[];

    authors: Author[];

    editorials: Editorial[];

    constructor(
        private authorService: AuthorService,
        private bookService: BookService,
        private editorialService: EditorialService,
        private genreService: GenreService
    ) {}

    ngOnInit() {
        this.loadServices();
    }

    private loadServices(): void {
        this.getAuthors();
        this.getBooks();
        this.getGenres();
        this.getEditorials();
    }

    getBooks(): void {
        this.bookService.getBooks().subscribe((response: any) => {
            this.books = response || [];
        });
    }

    getGenres(): void {
        this.genreService.getGenres().subscribe((response: any) => {
            this.genres = response || [];
        });
    }

    getAuthors(): void {
        this.authorService.getAuthors().subscribe((response: any) => {
            this.authors = response || [];
        });
    }

    getEditorials(): void {
        this.editorialService.getEditorials().subscribe((response: any) => {
            this.editorials = response || [];
        });
    }
}
