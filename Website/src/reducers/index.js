import { combineReducers } from 'redux';
import accessConstants from '../constants/accessConstants';
import common from './common';
import access from './access';
import userInfo from './userInfo';
import plantsInfo from './plantsInfo';

const appReducer = combineReducers({
    common,
    access,
    userInfo,
    plantsInfo
});

const rootReducer = (state, action) => {
    if (action.type === accessConstants.ACCESS_DENIAL) {
        state = undefined;
    }
    return appReducer(state, action);
};

export default rootReducer;
