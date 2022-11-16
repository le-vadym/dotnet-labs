import axios from 'axios';
import { ModelBase } from '../models';

export default class DataService<T extends ModelBase> {
    apiEndpoint: string;

    constructor (apiEndpoint: string) {
        this.apiEndpoint = apiEndpoint;
    }

    async getAll(): Promise<T[]> {
        const res = await axios.get(this.apiEndpoint);
        return res.status === 200 ? res.data : [];
    }

    async create(model: T): Promise<T> {
        const res = await axios.post(this.apiEndpoint, model);
        return res.status === 200 ? res.data : {};
    }

    async update(id: string, model: T): Promise<T> {
        const res = await axios.put(this.apiEndpoint + '/' + id, model);
        return res.status === 200 ? res.data : {};
    }

    async delete(id: string): Promise<boolean> {
        const res = await axios.delete(this.apiEndpoint + '/' + id);
        return res.status === 200;
    }

}
