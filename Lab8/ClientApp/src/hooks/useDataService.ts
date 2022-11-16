import { useMutation, useQuery, useQueryClient } from 'react-query';
import { ModelBase } from '../models';
import DataService from '../services/DataService';

const useDataService = <Model extends ModelBase>(service: DataService<Model>) => {
    const client = useQueryClient();

    const refetch = () => {
        client.invalidateQueries(service.apiEndpoint);
    };

    const queryAll = useQuery(
        service.apiEndpoint,
        async () => await service.getAll()
    );

    const createQuery = useMutation(
        async (model: Model) => await service.create(model),
        {
            onSuccess: (result) => {
                client.setQueriesData([service.apiEndpoint, result.id], result);
                refetch();
            }
        }
    );

    const updateQuery = useMutation(
        async ({id, model}: { id: string, model: Model }) => await service.update(id, model),
        {
            onSuccess: (result) => {
                client.setQueriesData([service.apiEndpoint, result.id], result);
                refetch();
            }
        }
    );

    const deleteQuery = useMutation(
        async (id: string) => await service.delete(id),
        {
            onSuccess: () => refetch()
        }
    );

    return {
        refetch,
        queryAll,
        createQuery,
        updateQuery,
        deleteQuery
    }
};

export default useDataService;
