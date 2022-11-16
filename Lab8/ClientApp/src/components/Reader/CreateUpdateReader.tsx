import React, { useState, useEffect } from 'react'
import { Form } from 'react-bootstrap';
import Select from 'react-select'
import { useLocation, useNavigate } from 'react-router-dom';
import useDataService from '../../hooks/useDataService'
import { Reader } from '../../models';
import ReaderService from '../../services/ReaderService';
import AddressService from '../../services/AddressService'

const CreateUpdateReader = () => {
    const { createQuery, updateQuery } = useDataService(ReaderService);
    const { queryAll: addressesQuery } = useDataService(AddressService);
    const { state: retrievedReader } = useLocation();
    const [reader, setReader] = useState(new Reader({}));
    const navigate = useNavigate();
    useEffect(() => {
        if (retrievedReader) {
            setReader(new Reader(retrievedReader));
        }
    }, [retrievedReader])

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const id = (retrievedReader as Reader)?.id;
        if (id) {
            await updateQuery.mutateAsync({ id, model: reader });
        } else {
            await createQuery.mutateAsync(reader);
        }
        goBack();
    };

    const goBack = () => navigate('/readers', { replace: true });

    const getAddressOptions = () => {
        if (!addressesQuery.isSuccess) {
            return [] as Array<{value: string, label: string}>;
        }
        
        return addressesQuery.data.map(address => ({ value: address.id, label: `${address.country}, ${address.city}, ${address.street}, ${address.houseNumber}` }))
    };

    const setAddress = (addressId: string) => {
        const address = addressesQuery.data?.filter(address => address.id === addressId)[0];
        if (address) {
            setReader({...reader, addressId: address.id, address});
        }
    };

    return (
        <>
            <h3>Reader</h3>
            <Form onSubmit={async (e) => await handleSubmit(e)}>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='First Name'
                        type='text'
                        name='firstName'
                        value={reader.firstName}
                        onChange={(e) => setReader(new Reader({ ...reader, firstName: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Last Name'
                        type='text'
                        name='lastName'
                        value={reader.lastName}
                        onChange={(e) => setReader(new Reader({ ...reader, lastName: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Birth Date'
                        type='date'
                        name='birthDate'
                        value={new Date(reader.birthDate).toLocaleDateString('en-Ca')}
                        onChange={(e) => setReader(new Reader({ ...reader, birthDate: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Phone Number'
                        type='text'
                        name='phoneNumber'
                        value={reader.phoneNumber}
                        onChange={(e) => setReader(new Reader({ ...reader, phoneNumber: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Select required
                        options={getAddressOptions()}
                        placeholder='Select Address'
                        onChange={(e) => setAddress(e?.value || '')}
                        isSearchable />
                </Form.Group>

                <button type='submit' className='btn btn-success m-1'>Update</button>
                <button className='btn btn-secondary m-1' onClick={goBack}>Go Back</button>
            </Form>
        </>
    )
}

export default CreateUpdateReader