import React, { useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import Plants from '../../components/Plants/Plants';

function PlantsPage({ history }) {
    const handleRedirection = plantId => () => {
        //clearGameInfo();
        history.push(`/my_plants/plant_info`);
    };

    useEffect(() => {
        //pullPlantsInfo();
    }, []);

    return (
        <Plants
            handleRedirection={handleRedirection}
        />
    );
}

PlantsPage.propTypes = {
    history: PropTypes.object.isRequired,
};

const mapStateToProps = store => {
    return {
        
    };
};

const mapDispatchToProps = dispatch => {
    return {
        
    };
};

export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps
)(PlantsPage));
