import React, { useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import PlantInfo from '../../components/Plants/PlantInfo';

function PlantInfoContainer({ history }) {
    useEffect(() => {
        //pullPlantsInfo();
    }, []);

    return (
        <PlantInfo
            
        />
    );
}

PlantInfoContainer.propTypes = {
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
)(PlantInfoContainer));
