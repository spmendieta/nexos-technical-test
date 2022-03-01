import { Component, OnInit } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { AuthorService } from 'src/app/service/author.service';
import { Book } from 'src/app/api/book';
import { BookService } from 'src/app/service/book.service';
import { Author } from 'src/app/api/author';
import { Editorial } from 'src/app/api/editorial';
import { Country } from 'src/app/api/country';
import { Province } from 'src/app/api/province';
import { City } from 'src/app/api/city';
import { Genre } from 'src/app/api/genre';

@Component({
    templateUrl: './dashboard.component.html',
    providers: [MessageService, ConfirmationService],
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

    countries: Country[];

    provinces: Province[];

    cities: City[];

    constructor(
        private authorService: AuthorService,
        private bookService: BookService,
        private messageService: MessageService
    ) {}

    ngOnInit() {
        this.getgetAuthors();
        this.getBooks();
    }

    getBooks(): void {
        this.bookService.getBooks().subscribe((response: any) => {
            this.books = response || [];
        });
    }

    getGenres(): void {

    }

    getgetAuthors(): void {
        this.authorService.getAuthors().subscribe((response: any) => {
            this.authors = response || [];
        });
    }

    getEditorials(): void {

    }

    getCountries(): void {

    }

    getProvinces(): void {

    }

    getCities(): void {

    }

    openNew() {
        //this.book = {};
        this.submitted = false;
        this.bookDialog = true;
    }

    hideDialog() {
        this.bookDialog = false;
        this.submitted = false;
    }

    saveProduct() {
        this.submitted = true;

        if (this.book.title.trim()) {
            if (this.book.bookId) {
                this.books[this.findIndexById(this.book.bookId)] = this.book;
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Updated',
                    life: 3000,
                });
            } else {
                this.book.bookId = this.createId();
                //this.book.image = 'product-placeholder.svg';
                this.books.push(this.book);
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Created',
                    life: 3000,
                });
            }

            this.books = [...this.books];
            this.bookDialog = false;
            //this.book = {};
        }
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.books.length; i++) {
            if (this.books[i].bookId === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): string {
        let id = '';
        var chars =
            'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (var i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        return id;
    }
}
