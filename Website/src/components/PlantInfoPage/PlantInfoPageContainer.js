import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import plantsInfoApiActions from '../../actions/plantsInfoApiActions';
import { AppBarContext } from '../TopAppBar/AppBarContext';
import UpwardButton from '../shared/UpwardButton';
import PlantInfoPage from './PlantInfoPage';

function PlantInfoPageContainer({ plantSensorReadings, getSensorReadings }) {
    const { resetAppBar } = React.useContext(AppBarContext);

    React.useEffect(() => {
        resetAppBar({
            title: 'Информация о растении',
            leftElement: <UpwardButton />
        });

        if (!plantSensorReadings.length) {
            getSensorReadings();
        }
    }, []);

    return (
        <PlantInfoPage plantSensorReadings={plantSensorReadings} />
    );
}

PlantInfoPageContainer.propTypes = {
    plantSensorReadings: PropTypes.array.isRequired,
    getSensorReadings: PropTypes.func.isRequired,
};

const mapStateToProps = store => {
    return {
        plantSensorReadings: store.plantsInfo.plantSensorReadings
    };
};

const mapDispatchToProps = dispatch => {
    return {
        getSensorReadings: () => dispatch(plantsInfoApiActions.getSensorReadings()),
    };
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(PlantInfoPageContainer);
