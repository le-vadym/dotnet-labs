export interface ModelBase {
    id: string
};

export class Book implements ModelBase {
    id: string;
    name: string;
    author: string;
    price: number;

    constructor(data: Book | any) {
        this.id = data.id ? data.id : crypto.randomUUID();
        this.name = data.name ? data.name : '';
        this.author = data.author ? data.author : '';
        this.price = data.price ? data.price : 0;
    }
};

export class Address implements ModelBase {
    id: string;
    country: string;
    region: string;
    city: string;
    street: string;
    houseNumber: number;

    constructor(data: Address | any) {
        this.id = data.id ? data.id : crypto.randomUUID();
        this.country = data.country ? data.country : '';
        this.region = data.region ? data.region : '';
        this.city = data.city ? data.city : '';
        this.street = data.street ? data.street : '';
        this.houseNumber = data.houseNumber ? data.houseNumber : '';
    }
}

export class Reader implements ModelBase {
    id: string;
    firstName: string;
    lastName: string;
    birthDate: Date;
    phoneNumber: string;
    address: Address;
    addressId: string;

    constructor(data: Reader | any) {
        this.id = data.id ? data.id : crypto.randomUUID();
        this.firstName = data.firstName ? data.firstName : '';
        this.lastName = data.lastName ? data.lastName : '';
        this.birthDate = data.birthDate ? data.birthDate : new Date();
        this.phoneNumber = data.phoneNumber ? data.phoneNumber : '';
        this.address = data.address ? data.address : new Address({});
        this.addressId = data.addressId ? data.addressId : '';
    }
}

export class BookBorrow implements ModelBase {
    id: string;
    book: Book
    bookId: string;
    reader: Reader
    readerId: string;
    borrowDate: Date;
    returnDate: Date;

    constructor(data: BookBorrow | any) {
        this.id = data.id ? data.id : crypto.randomUUID();
        this.book = data.book ? data.book : new Book({});
        this.bookId = data.bookId ? data.bookId : '';
        this.reader = data.reader ? data.reader : new Reader({});
        this.readerId = data.readerId ? data.readerId : '';
        this.borrowDate = data.borrowDate ? data.borrowDate : new Date();
        this.returnDate = data.returnDate ? data.returnDate : new Date();
    }

}
