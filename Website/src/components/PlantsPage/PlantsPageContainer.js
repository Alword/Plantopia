import React from 'react';
import PropTypes from 'prop-types';
import PlantsPage from '../../components/PlantsPage/PlantsPage';
import { AppBarContext } from '../TopAppBar/AppBarContext';

function PlantsPageContainer() {
    const { resetAppBar } = React.useContext(AppBarContext);

    React.useEffect(() => {
        resetAppBar({
            title: 'Мои растения'
        });
    }, []);

    return (
        <PlantsPage />
    );
}

PlantsPageContainer.propTypes = {
    history: PropTypes.object.isRequired,
};

export default PlantsPageContainer;
