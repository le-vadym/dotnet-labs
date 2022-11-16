import { BookBorrow } from '../models';
import DataService from './DataService'

class BookBorrowService extends DataService<BookBorrow> {
    constructor () {
        super('/api/BookBorrow');
    }
}

const instance = new BookBorrowService();

export default instance;
