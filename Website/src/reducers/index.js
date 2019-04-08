import { combineReducers } from 'redux';
import accessConstants from '../constants/accessConstants';
import dataTransferInProgress from './dataTransferInProgress';
import access from './access';
import userInfo from './userInfo';
import errorMessage from './errorMessage';

const appReducer = combineReducers({
    dataTransferInProgress,
    access,
    userInfo,
    errorMessage
});

const rootReducer = (state, action) => {
    if (action.type === accessConstants.ACCESS_DENIAL) {
        state = undefined;
    }
    return appReducer(state, action);
};

export default rootReducer;
