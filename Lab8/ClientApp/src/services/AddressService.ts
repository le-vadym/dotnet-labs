import { Address } from '../models';
import DataService from './DataService'

class AddressService extends DataService<Address> {
    constructor () {
        super('/api/Address');
    }
}

const instance = new AddressService();

export default instance;
