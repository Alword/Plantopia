import plantsInfoConstants from '../constants/plantsInfoConstants';

const initializePlantSensorReadings = plantSensorReadings => ({
    type: plantsInfoConstants.PLANT_SENSOR_READINGS_INITIALIZATION,
    payload: plantSensorReadings
});

export default {
    initializePlantSensorReadings
};