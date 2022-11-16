import React from 'react'
import useDataService from '../../hooks/useDataService'
import { Reader } from '../../models'
import ReaderService from '../../services/ReaderService'
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';

const Readers = () => {
    const { queryAll, deleteQuery } = useDataService(ReaderService);
    const navigate = useNavigate();

    const deleteReader = async (id: string) => {
        await deleteQuery.mutateAsync(id);
    };

    const content = queryAll.isLoading
        ? <h2>Loading...</h2>
        : queryAll.isError
            ? <h2>Error</h2>
            : <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Birth Date</th>
                        <th>Phone Number</th>
                        <th>Address</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {queryAll.data?.map((reader: Reader) =>
                        <tr key={reader.id}>
                            <td>
                                {reader.firstName}
                            </td>
                            <td>
                                {reader.lastName}
                            </td>
                            <td>
                                {new Date(reader.birthDate).toDateString()}
                            </td>
                            <td>
                                {reader.phoneNumber}
                            </td>
                            <td>
                                {reader.address.country}, {reader.address.city}, {reader.address.street}, {reader.address.houseNumber}
                            </td>
                            <td>
                                <button className='btn btn-warning' onClick={() => navigate('update', { state: reader, replace: true })}>Edit</button>{" | "}
                                <button className='btn btn-danger' onClick={async () => await deleteReader(reader.id)}>Delete</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>

    return (
        <>
            <h1>Index</h1>
            <p>
                <Link to='create' className='btn btn-success'>Create New</Link>
            </p>
            {content}
        </>
    )
}

export default Readers