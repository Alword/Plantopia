import apiAction from './apiAction';
import plantsInfoActions from './plantsInfoActions';

function getSensorReadings() {
    return apiAction({
        apiVersion: 'api',
        endpoint: 'Values/All',
        actionsOnSuccess: [plantsInfoActions.initializePlantSensorReadings],
        errorMessage: 'Не удалось загрузить показания датчиков'
    });
}

export default {
    getSensorReadings
};
