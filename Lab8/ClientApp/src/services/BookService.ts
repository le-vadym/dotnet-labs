import { Book } from '../models';
import DataService from './DataService'

class BookService extends DataService<Book> {
    constructor () {
        super('/api/Book');
    }
}

const instance = new BookService();

export default instance;
