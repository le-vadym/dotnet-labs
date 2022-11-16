import { Reader } from '../models';
import DataService from './DataService'

class ReaderService extends DataService<Reader> {
    constructor () {
        super('/api/Reader');
    }
}

const instance = new ReaderService();

export default instance;
