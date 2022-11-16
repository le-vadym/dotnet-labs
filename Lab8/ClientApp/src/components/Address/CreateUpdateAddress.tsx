import React, { useState, useEffect } from 'react'
import { Form } from 'react-bootstrap';
import { useLocation, useNavigate } from 'react-router-dom';
import useDataService from '../../hooks/useDataService'
import { Address } from '../../models';
import AddressService from '../../services/AddressService';

const CreateUpdateAddress = () => {
    const { createQuery, updateQuery } = useDataService(AddressService);
    const { state: retrievedAddress } = useLocation();
    const [address, setAddress] = useState(new Address({}));
    const navigate = useNavigate();
    useEffect(() => {
        if (retrievedAddress) {
            setAddress(new Address(retrievedAddress));
        }
    }, [retrievedAddress]);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const id = (retrievedAddress as Address)?.id;
        if (id) {
            await updateQuery.mutateAsync({ id, model: address });
        } else {
            await createQuery.mutateAsync(address);
        }
        goBack();
    };

    const goBack = () => navigate('/addresses', { replace: true });

    return (
        <>
            <h3>Address</h3>
            <Form onSubmit={async (e) => await handleSubmit(e)}>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Country'
                        type='text'
                        name='country'
                        value={address.country}
                        onChange={(e) => setAddress(new Address({ ...address, country: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Region'
                        type='text'
                        name='region'
                        value={address.region}
                        onChange={(e) => setAddress(new Address({ ...address, region: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='City'
                        type='text'
                        name='city'
                        value={address.city}
                        onChange={(e) => setAddress(new Address({ ...address, city: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Street'
                        type='text'
                        name='street'
                        value={address.street}
                        onChange={(e) => setAddress(new Address({ ...address, street: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='House Number'
                        type='text'
                        name='houseNumber'
                        value={address.houseNumber}
                        onChange={(e) => setAddress(new Address({ ...address, houseNumber: Number(e.target.value) }))} />
                </Form.Group>

                <button type='submit' className='btn btn-success m-1'>Update</button>
                <button className='btn btn-secondary m-1' onClick={goBack}>Go Back</button>
            </Form>
        </>
    )
}

export default CreateUpdateAddress