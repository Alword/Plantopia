import plantsInfoConstants from '../constants/plantsInfoConstants';
import { combineReducers } from 'redux';

const plantSensorReadings = (state = [], action) => {
    switch (action.type) {
        case plantsInfoConstants.PLANT_SENSOR_READINGS_INITIALIZATION:
            return action.payload;
        default:
            return state;
    }
};

const plantsInfo = combineReducers({
    plantSensorReadings
});

export default plantsInfo;
